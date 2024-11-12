using GameDevArtistPlatform.APIs;
using GameDevArtistPlatform.APIs.Common;
using GameDevArtistPlatform.APIs.Dtos;
using GameDevArtistPlatform.APIs.Errors;
using GameDevArtistPlatform.APIs.Extensions;
using GameDevArtistPlatform.Infrastructure;
using GameDevArtistPlatform.Infrastructure.Models;
using Microsoft.EntityFrameworkCore;

namespace GameDevArtistPlatform.APIs;

public abstract class MockTestsServiceBase : IMockTestsService
{
    protected readonly GameDevArtistPlatformDbContext _context;

    public MockTestsServiceBase(GameDevArtistPlatformDbContext context)
    {
        _context = context;
    }

    /// <summary>
    /// Create one MockTest
    /// </summary>
    public async Task<MockTest> CreateMockTest(MockTestCreateInput createDto)
    {
        var mockTest = new MockTestDbModel
        {
            CreatedAt = createDto.CreatedAt,
            UpdatedAt = createDto.UpdatedAt
        };

        if (createDto.Id != null)
        {
            mockTest.Id = createDto.Id;
        }

        _context.MockTests.Add(mockTest);
        await _context.SaveChangesAsync();

        var result = await _context.FindAsync<MockTestDbModel>(mockTest.Id);

        if (result == null)
        {
            throw new NotFoundException();
        }

        return result.ToDto();
    }

    /// <summary>
    /// Delete one MockTest
    /// </summary>
    public async Task DeleteMockTest(MockTestWhereUniqueInput uniqueId)
    {
        var mockTest = await _context.MockTests.FindAsync(uniqueId.Id);
        if (mockTest == null)
        {
            throw new NotFoundException();
        }

        _context.MockTests.Remove(mockTest);
        await _context.SaveChangesAsync();
    }

    /// <summary>
    /// Find many MockTests
    /// </summary>
    public async Task<List<MockTest>> MockTests(MockTestFindManyArgs findManyArgs)
    {
        var mockTests = await _context
            .MockTests.ApplyWhere(findManyArgs.Where)
            .ApplySkip(findManyArgs.Skip)
            .ApplyTake(findManyArgs.Take)
            .ApplyOrderBy(findManyArgs.SortBy)
            .ToListAsync();
        return mockTests.ConvertAll(mockTest => mockTest.ToDto());
    }

    /// <summary>
    /// Meta data about MockTest records
    /// </summary>
    public async Task<MetadataDto> MockTestsMeta(MockTestFindManyArgs findManyArgs)
    {
        var count = await _context.MockTests.ApplyWhere(findManyArgs.Where).CountAsync();

        return new MetadataDto { Count = count };
    }

    /// <summary>
    /// Get one MockTest
    /// </summary>
    public async Task<MockTest> MockTest(MockTestWhereUniqueInput uniqueId)
    {
        var mockTests = await this.MockTests(
            new MockTestFindManyArgs { Where = new MockTestWhereInput { Id = uniqueId.Id } }
        );
        var mockTest = mockTests.FirstOrDefault();
        if (mockTest == null)
        {
            throw new NotFoundException();
        }

        return mockTest;
    }

    /// <summary>
    /// Update one MockTest
    /// </summary>
    public async Task UpdateMockTest(
        MockTestWhereUniqueInput uniqueId,
        MockTestUpdateInput updateDto
    )
    {
        var mockTest = updateDto.ToModel(uniqueId);

        _context.Entry(mockTest).State = EntityState.Modified;

        try
        {
            await _context.SaveChangesAsync();
        }
        catch (DbUpdateConcurrencyException)
        {
            if (!_context.MockTests.Any(e => e.Id == mockTest.Id))
            {
                throw new NotFoundException();
            }
            else
            {
                throw;
            }
        }
    }
}

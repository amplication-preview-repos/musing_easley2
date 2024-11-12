using GameDevArtistPlatform.APIs;
using GameDevArtistPlatform.APIs.Common;
using GameDevArtistPlatform.APIs.Dtos;
using GameDevArtistPlatform.APIs.Errors;
using GameDevArtistPlatform.APIs.Extensions;
using GameDevArtistPlatform.Infrastructure;
using GameDevArtistPlatform.Infrastructure.Models;
using Microsoft.EntityFrameworkCore;

namespace GameDevArtistPlatform.APIs;

public abstract class InstitutionsServiceBase : IInstitutionsService
{
    protected readonly GameDevArtistPlatformDbContext _context;

    public InstitutionsServiceBase(GameDevArtistPlatformDbContext context)
    {
        _context = context;
    }

    /// <summary>
    /// Create one Institution
    /// </summary>
    public async Task<Institution> CreateInstitution(InstitutionCreateInput createDto)
    {
        var institution = new InstitutionDbModel
        {
            CreatedAt = createDto.CreatedAt,
            UpdatedAt = createDto.UpdatedAt
        };

        if (createDto.Id != null)
        {
            institution.Id = createDto.Id;
        }

        _context.Institutions.Add(institution);
        await _context.SaveChangesAsync();

        var result = await _context.FindAsync<InstitutionDbModel>(institution.Id);

        if (result == null)
        {
            throw new NotFoundException();
        }

        return result.ToDto();
    }

    /// <summary>
    /// Delete one Institution
    /// </summary>
    public async Task DeleteInstitution(InstitutionWhereUniqueInput uniqueId)
    {
        var institution = await _context.Institutions.FindAsync(uniqueId.Id);
        if (institution == null)
        {
            throw new NotFoundException();
        }

        _context.Institutions.Remove(institution);
        await _context.SaveChangesAsync();
    }

    /// <summary>
    /// Find many Institutions
    /// </summary>
    public async Task<List<Institution>> Institutions(InstitutionFindManyArgs findManyArgs)
    {
        var institutions = await _context
            .Institutions.ApplyWhere(findManyArgs.Where)
            .ApplySkip(findManyArgs.Skip)
            .ApplyTake(findManyArgs.Take)
            .ApplyOrderBy(findManyArgs.SortBy)
            .ToListAsync();
        return institutions.ConvertAll(institution => institution.ToDto());
    }

    /// <summary>
    /// Meta data about Institution records
    /// </summary>
    public async Task<MetadataDto> InstitutionsMeta(InstitutionFindManyArgs findManyArgs)
    {
        var count = await _context.Institutions.ApplyWhere(findManyArgs.Where).CountAsync();

        return new MetadataDto { Count = count };
    }

    /// <summary>
    /// Get one Institution
    /// </summary>
    public async Task<Institution> Institution(InstitutionWhereUniqueInput uniqueId)
    {
        var institutions = await this.Institutions(
            new InstitutionFindManyArgs { Where = new InstitutionWhereInput { Id = uniqueId.Id } }
        );
        var institution = institutions.FirstOrDefault();
        if (institution == null)
        {
            throw new NotFoundException();
        }

        return institution;
    }

    /// <summary>
    /// Update one Institution
    /// </summary>
    public async Task UpdateInstitution(
        InstitutionWhereUniqueInput uniqueId,
        InstitutionUpdateInput updateDto
    )
    {
        var institution = updateDto.ToModel(uniqueId);

        _context.Entry(institution).State = EntityState.Modified;

        try
        {
            await _context.SaveChangesAsync();
        }
        catch (DbUpdateConcurrencyException)
        {
            if (!_context.Institutions.Any(e => e.Id == institution.Id))
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

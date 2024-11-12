using GameDevArtistPlatform.APIs;
using GameDevArtistPlatform.APIs.Common;
using GameDevArtistPlatform.APIs.Dtos;
using GameDevArtistPlatform.APIs.Errors;
using GameDevArtistPlatform.APIs.Extensions;
using GameDevArtistPlatform.Infrastructure;
using GameDevArtistPlatform.Infrastructure.Models;
using Microsoft.EntityFrameworkCore;

namespace GameDevArtistPlatform.APIs;

public abstract class CompaniesServiceBase : ICompaniesService
{
    protected readonly GameDevArtistPlatformDbContext _context;

    public CompaniesServiceBase(GameDevArtistPlatformDbContext context)
    {
        _context = context;
    }

    /// <summary>
    /// Create one Company
    /// </summary>
    public async Task<Company> CreateCompany(CompanyCreateInput createDto)
    {
        var company = new CompanyDbModel
        {
            CreatedAt = createDto.CreatedAt,
            UpdatedAt = createDto.UpdatedAt
        };

        if (createDto.Id != null)
        {
            company.Id = createDto.Id;
        }

        _context.Companies.Add(company);
        await _context.SaveChangesAsync();

        var result = await _context.FindAsync<CompanyDbModel>(company.Id);

        if (result == null)
        {
            throw new NotFoundException();
        }

        return result.ToDto();
    }

    /// <summary>
    /// Delete one Company
    /// </summary>
    public async Task DeleteCompany(CompanyWhereUniqueInput uniqueId)
    {
        var company = await _context.Companies.FindAsync(uniqueId.Id);
        if (company == null)
        {
            throw new NotFoundException();
        }

        _context.Companies.Remove(company);
        await _context.SaveChangesAsync();
    }

    /// <summary>
    /// Find many Companies
    /// </summary>
    public async Task<List<Company>> Companies(CompanyFindManyArgs findManyArgs)
    {
        var companies = await _context
            .Companies.ApplyWhere(findManyArgs.Where)
            .ApplySkip(findManyArgs.Skip)
            .ApplyTake(findManyArgs.Take)
            .ApplyOrderBy(findManyArgs.SortBy)
            .ToListAsync();
        return companies.ConvertAll(company => company.ToDto());
    }

    /// <summary>
    /// Meta data about Company records
    /// </summary>
    public async Task<MetadataDto> CompaniesMeta(CompanyFindManyArgs findManyArgs)
    {
        var count = await _context.Companies.ApplyWhere(findManyArgs.Where).CountAsync();

        return new MetadataDto { Count = count };
    }

    /// <summary>
    /// Get one Company
    /// </summary>
    public async Task<Company> Company(CompanyWhereUniqueInput uniqueId)
    {
        var companies = await this.Companies(
            new CompanyFindManyArgs { Where = new CompanyWhereInput { Id = uniqueId.Id } }
        );
        var company = companies.FirstOrDefault();
        if (company == null)
        {
            throw new NotFoundException();
        }

        return company;
    }

    /// <summary>
    /// Update one Company
    /// </summary>
    public async Task UpdateCompany(CompanyWhereUniqueInput uniqueId, CompanyUpdateInput updateDto)
    {
        var company = updateDto.ToModel(uniqueId);

        _context.Entry(company).State = EntityState.Modified;

        try
        {
            await _context.SaveChangesAsync();
        }
        catch (DbUpdateConcurrencyException)
        {
            if (!_context.Companies.Any(e => e.Id == company.Id))
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

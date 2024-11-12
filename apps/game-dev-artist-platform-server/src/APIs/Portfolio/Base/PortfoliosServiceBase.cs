using GameDevArtistPlatform.APIs;
using GameDevArtistPlatform.APIs.Common;
using GameDevArtistPlatform.APIs.Dtos;
using GameDevArtistPlatform.APIs.Errors;
using GameDevArtistPlatform.APIs.Extensions;
using GameDevArtistPlatform.Infrastructure;
using GameDevArtistPlatform.Infrastructure.Models;
using Microsoft.EntityFrameworkCore;

namespace GameDevArtistPlatform.APIs;

public abstract class PortfoliosServiceBase : IPortfoliosService
{
    protected readonly GameDevArtistPlatformDbContext _context;

    public PortfoliosServiceBase(GameDevArtistPlatformDbContext context)
    {
        _context = context;
    }

    /// <summary>
    /// Create one Portfolio
    /// </summary>
    public async Task<Portfolio> CreatePortfolio(PortfolioCreateInput createDto)
    {
        var portfolio = new PortfolioDbModel
        {
            CreatedAt = createDto.CreatedAt,
            UpdatedAt = createDto.UpdatedAt
        };

        if (createDto.Id != null)
        {
            portfolio.Id = createDto.Id;
        }

        _context.Portfolios.Add(portfolio);
        await _context.SaveChangesAsync();

        var result = await _context.FindAsync<PortfolioDbModel>(portfolio.Id);

        if (result == null)
        {
            throw new NotFoundException();
        }

        return result.ToDto();
    }

    /// <summary>
    /// Delete one Portfolio
    /// </summary>
    public async Task DeletePortfolio(PortfolioWhereUniqueInput uniqueId)
    {
        var portfolio = await _context.Portfolios.FindAsync(uniqueId.Id);
        if (portfolio == null)
        {
            throw new NotFoundException();
        }

        _context.Portfolios.Remove(portfolio);
        await _context.SaveChangesAsync();
    }

    /// <summary>
    /// Find many Portfolios
    /// </summary>
    public async Task<List<Portfolio>> Portfolios(PortfolioFindManyArgs findManyArgs)
    {
        var portfolios = await _context
            .Portfolios.ApplyWhere(findManyArgs.Where)
            .ApplySkip(findManyArgs.Skip)
            .ApplyTake(findManyArgs.Take)
            .ApplyOrderBy(findManyArgs.SortBy)
            .ToListAsync();
        return portfolios.ConvertAll(portfolio => portfolio.ToDto());
    }

    /// <summary>
    /// Meta data about Portfolio records
    /// </summary>
    public async Task<MetadataDto> PortfoliosMeta(PortfolioFindManyArgs findManyArgs)
    {
        var count = await _context.Portfolios.ApplyWhere(findManyArgs.Where).CountAsync();

        return new MetadataDto { Count = count };
    }

    /// <summary>
    /// Get one Portfolio
    /// </summary>
    public async Task<Portfolio> Portfolio(PortfolioWhereUniqueInput uniqueId)
    {
        var portfolios = await this.Portfolios(
            new PortfolioFindManyArgs { Where = new PortfolioWhereInput { Id = uniqueId.Id } }
        );
        var portfolio = portfolios.FirstOrDefault();
        if (portfolio == null)
        {
            throw new NotFoundException();
        }

        return portfolio;
    }

    /// <summary>
    /// Update one Portfolio
    /// </summary>
    public async Task UpdatePortfolio(
        PortfolioWhereUniqueInput uniqueId,
        PortfolioUpdateInput updateDto
    )
    {
        var portfolio = updateDto.ToModel(uniqueId);

        _context.Entry(portfolio).State = EntityState.Modified;

        try
        {
            await _context.SaveChangesAsync();
        }
        catch (DbUpdateConcurrencyException)
        {
            if (!_context.Portfolios.Any(e => e.Id == portfolio.Id))
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

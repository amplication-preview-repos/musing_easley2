using GameDevArtistPlatform.APIs.Common;
using GameDevArtistPlatform.APIs.Dtos;

namespace GameDevArtistPlatform.APIs;

public interface IPortfoliosService
{
    /// <summary>
    /// Create one Portfolio
    /// </summary>
    public Task<Portfolio> CreatePortfolio(PortfolioCreateInput portfolio);

    /// <summary>
    /// Delete one Portfolio
    /// </summary>
    public Task DeletePortfolio(PortfolioWhereUniqueInput uniqueId);

    /// <summary>
    /// Find many Portfolios
    /// </summary>
    public Task<List<Portfolio>> Portfolios(PortfolioFindManyArgs findManyArgs);

    /// <summary>
    /// Meta data about Portfolio records
    /// </summary>
    public Task<MetadataDto> PortfoliosMeta(PortfolioFindManyArgs findManyArgs);

    /// <summary>
    /// Get one Portfolio
    /// </summary>
    public Task<Portfolio> Portfolio(PortfolioWhereUniqueInput uniqueId);

    /// <summary>
    /// Update one Portfolio
    /// </summary>
    public Task UpdatePortfolio(PortfolioWhereUniqueInput uniqueId, PortfolioUpdateInput updateDto);
}

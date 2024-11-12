using GameDevArtistPlatform.APIs.Common;
using GameDevArtistPlatform.APIs.Dtos;

namespace GameDevArtistPlatform.APIs;

public interface IAnalyticsItemsService
{
    /// <summary>
    /// Create one Analytics
    /// </summary>
    public Task<Analytics> CreateAnalytics(AnalyticsCreateInput analytics);

    /// <summary>
    /// Delete one Analytics
    /// </summary>
    public Task DeleteAnalytics(AnalyticsWhereUniqueInput uniqueId);

    /// <summary>
    /// Find many AnalyticsItems
    /// </summary>
    public Task<List<Analytics>> AnalyticsItems(AnalyticsFindManyArgs findManyArgs);

    /// <summary>
    /// Meta data about Analytics records
    /// </summary>
    public Task<MetadataDto> AnalyticsItemsMeta(AnalyticsFindManyArgs findManyArgs);

    /// <summary>
    /// Get one Analytics
    /// </summary>
    public Task<Analytics> Analytics(AnalyticsWhereUniqueInput uniqueId);

    /// <summary>
    /// Update one Analytics
    /// </summary>
    public Task UpdateAnalytics(AnalyticsWhereUniqueInput uniqueId, AnalyticsUpdateInput updateDto);
}

using GameDevArtistPlatform.Infrastructure;

namespace GameDevArtistPlatform.APIs;

public class AnalyticsItemsService : AnalyticsItemsServiceBase
{
    public AnalyticsItemsService(GameDevArtistPlatformDbContext context)
        : base(context) { }
}

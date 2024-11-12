using GameDevArtistPlatform.Infrastructure;

namespace GameDevArtistPlatform.APIs;

public class FeedbacksService : FeedbacksServiceBase
{
    public FeedbacksService(GameDevArtistPlatformDbContext context)
        : base(context) { }
}

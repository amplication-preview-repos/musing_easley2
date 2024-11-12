using GameDevArtistPlatform.Infrastructure;

namespace GameDevArtistPlatform.APIs;

public class RewardsService : RewardsServiceBase
{
    public RewardsService(GameDevArtistPlatformDbContext context)
        : base(context) { }
}

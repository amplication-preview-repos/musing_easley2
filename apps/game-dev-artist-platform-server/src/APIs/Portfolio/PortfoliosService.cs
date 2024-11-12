using GameDevArtistPlatform.Infrastructure;

namespace GameDevArtistPlatform.APIs;

public class PortfoliosService : PortfoliosServiceBase
{
    public PortfoliosService(GameDevArtistPlatformDbContext context)
        : base(context) { }
}

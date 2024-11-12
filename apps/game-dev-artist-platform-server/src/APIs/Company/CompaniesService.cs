using GameDevArtistPlatform.Infrastructure;

namespace GameDevArtistPlatform.APIs;

public class CompaniesService : CompaniesServiceBase
{
    public CompaniesService(GameDevArtistPlatformDbContext context)
        : base(context) { }
}

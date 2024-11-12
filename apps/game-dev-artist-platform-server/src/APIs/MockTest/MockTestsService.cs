using GameDevArtistPlatform.Infrastructure;

namespace GameDevArtistPlatform.APIs;

public class MockTestsService : MockTestsServiceBase
{
    public MockTestsService(GameDevArtistPlatformDbContext context)
        : base(context) { }
}

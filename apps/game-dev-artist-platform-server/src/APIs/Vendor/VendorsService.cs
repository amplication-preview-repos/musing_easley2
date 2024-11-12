using GameDevArtistPlatform.Infrastructure;

namespace GameDevArtistPlatform.APIs;

public class VendorsService : VendorsServiceBase
{
    public VendorsService(GameDevArtistPlatformDbContext context)
        : base(context) { }
}

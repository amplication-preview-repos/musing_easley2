using GameDevArtistPlatform.Infrastructure;

namespace GameDevArtistPlatform.APIs;

public class InstitutionsService : InstitutionsServiceBase
{
    public InstitutionsService(GameDevArtistPlatformDbContext context)
        : base(context) { }
}

using GameDevArtistPlatform.Infrastructure;

namespace GameDevArtistPlatform.APIs;

public class UsersService : UsersServiceBase
{
    public UsersService(GameDevArtistPlatformDbContext context)
        : base(context) { }
}

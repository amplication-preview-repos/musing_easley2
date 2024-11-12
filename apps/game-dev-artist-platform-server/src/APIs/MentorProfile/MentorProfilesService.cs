using GameDevArtistPlatform.Infrastructure;

namespace GameDevArtistPlatform.APIs;

public class MentorProfilesService : MentorProfilesServiceBase
{
    public MentorProfilesService(GameDevArtistPlatformDbContext context)
        : base(context) { }
}

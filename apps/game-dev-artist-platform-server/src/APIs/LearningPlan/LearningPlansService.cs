using GameDevArtistPlatform.Infrastructure;

namespace GameDevArtistPlatform.APIs;

public class LearningPlansService : LearningPlansServiceBase
{
    public LearningPlansService(GameDevArtistPlatformDbContext context)
        : base(context) { }
}

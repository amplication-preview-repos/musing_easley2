using Microsoft.AspNetCore.Mvc;

namespace GameDevArtistPlatform.APIs;

[ApiController()]
public class LearningPlansController : LearningPlansControllerBase
{
    public LearningPlansController(ILearningPlansService service)
        : base(service) { }
}

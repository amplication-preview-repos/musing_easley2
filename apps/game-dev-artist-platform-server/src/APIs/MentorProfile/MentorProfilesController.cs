using Microsoft.AspNetCore.Mvc;

namespace GameDevArtistPlatform.APIs;

[ApiController()]
public class MentorProfilesController : MentorProfilesControllerBase
{
    public MentorProfilesController(IMentorProfilesService service)
        : base(service) { }
}

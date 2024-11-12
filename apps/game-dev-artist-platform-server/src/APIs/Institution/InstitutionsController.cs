using Microsoft.AspNetCore.Mvc;

namespace GameDevArtistPlatform.APIs;

[ApiController()]
public class InstitutionsController : InstitutionsControllerBase
{
    public InstitutionsController(IInstitutionsService service)
        : base(service) { }
}

using Microsoft.AspNetCore.Mvc;

namespace GameDevArtistPlatform.APIs;

[ApiController()]
public class CompaniesController : CompaniesControllerBase
{
    public CompaniesController(ICompaniesService service)
        : base(service) { }
}

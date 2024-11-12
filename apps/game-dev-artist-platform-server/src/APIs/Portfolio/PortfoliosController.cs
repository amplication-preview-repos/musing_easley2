using Microsoft.AspNetCore.Mvc;

namespace GameDevArtistPlatform.APIs;

[ApiController()]
public class PortfoliosController : PortfoliosControllerBase
{
    public PortfoliosController(IPortfoliosService service)
        : base(service) { }
}

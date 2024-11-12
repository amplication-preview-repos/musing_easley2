using Microsoft.AspNetCore.Mvc;

namespace GameDevArtistPlatform.APIs;

[ApiController()]
public class VendorsController : VendorsControllerBase
{
    public VendorsController(IVendorsService service)
        : base(service) { }
}

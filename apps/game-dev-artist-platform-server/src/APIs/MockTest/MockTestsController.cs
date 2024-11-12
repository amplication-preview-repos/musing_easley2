using Microsoft.AspNetCore.Mvc;

namespace GameDevArtistPlatform.APIs;

[ApiController()]
public class MockTestsController : MockTestsControllerBase
{
    public MockTestsController(IMockTestsService service)
        : base(service) { }
}

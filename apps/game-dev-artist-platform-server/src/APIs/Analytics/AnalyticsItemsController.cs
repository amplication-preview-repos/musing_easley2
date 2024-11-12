using Microsoft.AspNetCore.Mvc;

namespace GameDevArtistPlatform.APIs;

[ApiController()]
public class AnalyticsItemsController : AnalyticsItemsControllerBase
{
    public AnalyticsItemsController(IAnalyticsItemsService service)
        : base(service) { }
}

using Microsoft.AspNetCore.Mvc;

namespace GameDevArtistPlatform.APIs;

[ApiController()]
public class RewardsController : RewardsControllerBase
{
    public RewardsController(IRewardsService service)
        : base(service) { }
}

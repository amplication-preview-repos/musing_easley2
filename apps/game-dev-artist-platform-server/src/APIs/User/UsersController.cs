using Microsoft.AspNetCore.Mvc;

namespace GameDevArtistPlatform.APIs;

[ApiController()]
public class UsersController : UsersControllerBase
{
    public UsersController(IUsersService service)
        : base(service) { }
}

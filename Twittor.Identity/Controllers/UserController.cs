using Microsoft.AspNetCore.Mvc;
using Twittor.Identity.Services;

namespace Twittor.Identity.Controllers
{
    public class UserController : ControllerBase
    {
        private readonly IUserService UserService;

        public UserController(IUserService userService)
        {
            UserService = userService;
        }

        public IActionResult Get()
        {
            return Ok();
        }
    }
}

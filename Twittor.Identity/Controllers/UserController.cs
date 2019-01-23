using Microsoft.AspNetCore.Mvc;
using System.Linq;
using System.Threading.Tasks;
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

        public async Task<IActionResult> Add(string email, string password)
        {
            var user = await UserService.CreateUser(email, password);
            return new JsonResult(user);
        }
    }
}

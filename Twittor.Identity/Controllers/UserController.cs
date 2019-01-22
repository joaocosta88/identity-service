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

        public IActionResult Get()
        {
            var users = UserService.GetAll();
            return Ok(users.ToList());
        }

        public async Task<IActionResult> Add()
        {
            await UserService.CreateUser(null);
            return RedirectToAction("Get");
        }
    }
}

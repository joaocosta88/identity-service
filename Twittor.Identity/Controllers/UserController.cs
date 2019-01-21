using Microsoft.AspNetCore.Mvc;
using System.Linq;
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

        public IActionResult Add()
        {
            var user = UserService.CreateUser();
            return RedirectToAction("Get");
        }
    }
}

using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using Twittor.Identity.Services;
using Twittor.Identity.Web.Models;

namespace Twittor.Identity.Controllers
{
    public class UserController : ControllerBase
    {
        private readonly IUserService UserService;

        public UserController(IUserService userService)
        {
            UserService = userService;
        }

        [HttpPost]
        public async Task<IActionResult> Authenticate([FromBody]AuthenticateUserModel model)
        {
            if (model == null || string.IsNullOrWhiteSpace(model.Email) || string.IsNullOrWhiteSpace(model.Password))
            {
                return new BadRequestResult();
            }
            if (await UserService.FindUserByEmailAsync(model.Email) == null)
            {
                return new BadRequestResult();
            }

            var isUserPassword = await UserService.IsUserPassword(model.Email, model.Password);
            return new JsonResult(isUserPassword);
        }

        [HttpPost]
        public async Task<IActionResult> Register([FromBody]RegisterUserModel model)
        {
            if (model == null || string.IsNullOrWhiteSpace(model.Email) || string.IsNullOrWhiteSpace(model.Password))
            {
                return new BadRequestResult();
            }
            if (await UserService.FindUserByEmailAsync(model.Email) != null)
            {
                return new BadRequestResult();
            }

            var user = await UserService.CreateUser(model.Email, model.Password);
            return new JsonResult(user);
        }
    }
}

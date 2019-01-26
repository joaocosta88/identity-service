using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using Twittor.Identity.JWT;
using Twittor.Identity.Services;
using Twittor.Identity.Web.Models;

namespace Twittor.Identity.Controllers
{
    [ApiController]
    [Route("users")]
    public class UsersController : ControllerBase
    {
        private readonly IUserService UserService;
        private readonly JWTGenerator JWTGenerator;

        public UsersController(IUserService userService, JWTGenerator jwtGenerator)
        {
            UserService = userService;
            JWTGenerator = jwtGenerator;
        }

        [HttpPost]
        [Route("authenticate")]
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

            if (!await UserService.IsUserPassword(model.Email, model.Password))
            {
                return new BadRequestResult();
            }

            var authToken = JWTGenerator.GenerateToken(model.Email);
            return new JsonResult(
                new
                {
                    token = authToken
                });
        }

        [HttpPost]
        [Route("register")]
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

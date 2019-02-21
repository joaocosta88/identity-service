using Microsoft.AspNetCore.Mvc;

namespace Identity.Web.Controllers
{
    [ApiController]
    [Route("home")]
    public class HomeController : ControllerBase
    {
        [HttpGet]
        [Route("index")]
        public IActionResult Index()
        {
            return new OkResult();
        }
    }
}

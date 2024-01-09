using Microsoft.AspNetCore.Mvc;

namespace BookApi.Controllers
{
    [ApiController]
    [Route("api/[Controller]/[action]")]
    public class LoginController : Controller
    {
        [HttpGet]
        public IActionResult validateUser()
        {
            return View();
        }
    }
}

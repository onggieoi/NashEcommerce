using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace client.Controllers
{
    public class AuthController : Controller
    {

        [HttpGet("/logout")]
        public IActionResult Logout()
        {
            return SignOut("Cookies", "oidc");
        }

        [Authorize]
        [HttpGet("/login")]
        public IActionResult login()
        {
            return RedirectToAction("Index", "Home");
        }
    }
}
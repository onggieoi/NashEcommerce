using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication;
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

        [HttpGet("/login")]
        public async Task login()
        {
            await HttpContext.ChallengeAsync(new AuthenticationProperties { RedirectUri = "/" });
        }
    }
}
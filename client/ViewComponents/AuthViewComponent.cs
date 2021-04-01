using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace client.ViewComponents
{
    [ViewComponent(Name = "Auth")]
    public class AuthViewComponent : ViewComponent
    {
        public async Task<IViewComponentResult> InvokeAsync()
        {
            if (User.Identity.IsAuthenticated)
            {
                var claimsIdentity = User.Identity as ClaimsIdentity;

                var name = claimsIdentity.FindFirst("name").Value;

                await Task.CompletedTask;

                return View("Default", name);
            }

            await Task.CompletedTask;

            return View();
        }
    }
}
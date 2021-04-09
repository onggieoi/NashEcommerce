using System.Security.Claims;
using System.Threading.Tasks;
using client.Models;
using client.Services;
using Microsoft.AspNetCore.Mvc;

namespace client.ViewComponents
{
    [ViewComponent(Name = "Header")]
    public class HeaderViewComponent : ViewComponent
    {
        private IHttpClientService _client;

        public HeaderViewComponent(IHttpClientService client)
        {
            _client = client;
        }
        public async Task<IViewComponentResult> InvokeAsync()
        {
            var name = "";
            if (User.Identity.IsAuthenticated)
            {
                // var claimsIdentity = User.Identity as ClaimsIdentity;
                // name = claimsIdentity.FindFirst("name").Value.ToString();
                name = User.Identity.Name;
            }

            var categories = await _client.GetCategories();

            var headerVM = new HeaderViewModel
            {
                Categories = categories,
                UserName = name,
            };

            return View("Default", headerVM);
        }
    }
}
using System.Security.Claims;
using System.Threading.Tasks;
using client.Models;
using client.Services;
using Microsoft.AspNetCore.Mvc;
using ViewModelShare.Product;

namespace client.ViewComponents
{
    [ViewComponent(Name = "Product")]
    public class ProductViewComponent : ViewComponent
    {
        private IHttpClientService _client;

        public ProductViewComponent(IHttpClientService client)
        {
            _client = client;
        }
        public async Task<IViewComponentResult> InvokeAsync(ProductRespone product)
        {
            await Task.CompletedTask;
            return View("Default", product);
        }
    }
}
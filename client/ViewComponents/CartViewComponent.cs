using System.Threading.Tasks;
using client.Services.Cart;
using Microsoft.AspNetCore.Mvc;

namespace client.ViewComponents
{
    [ViewComponent(Name = "Cart")]
    public class CartViewComponent : ViewComponent
    {
        private readonly ICartService _cartService;

        public CartViewComponent(ICartService cartService)
        {
            _cartService = cartService;
        }
        public async Task<IViewComponentResult> InvokeAsync()
        {
            var cartVM = _cartService.GetCartViewModel();

            await Task.CompletedTask;
            return View("Default", cartVM);
        }
    }
}
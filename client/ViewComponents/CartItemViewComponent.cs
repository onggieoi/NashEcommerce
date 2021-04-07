using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ViewModelShare.CartOrder;

namespace client.ViewComponents
{
    [ViewComponent(Name = "CartItem")]
    public class CartItemViewComponent : ViewComponent
    {
        public async Task<IViewComponentResult> InvokeAsync(CartOrderRespone cartOrder)
        {
            return await Task.FromResult(View("Default", cartOrder));
        }
    }
}
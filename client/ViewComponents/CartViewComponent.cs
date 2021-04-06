using System.Collections.Generic;
using System.Threading.Tasks;
using client.Constants;
using client.Extensions;
using client.Models;
using Microsoft.AspNetCore.Mvc;
using ViewModelShare.CartOrder;

namespace client.ViewComponents
{
    [ViewComponent(Name = "Cart")]
    public class CartViewComponent : ViewComponent
    {
        public async Task<IViewComponentResult> InvokeAsync()
        {
            var orders = HttpContext.Session.GetObject<List<CartOrderRespone>>(SessionKeys.Cart);

            var count = 0;
            var total = 0;

            orders?.ForEach(order =>
            {
                count += order.Quantity;
                total += order.Quantity * order.Product.Price;
            });

            var cartVM = new CartViewModel
            {
                Total = total,
                Count = count,
            };

            await Task.CompletedTask;
            return View("Default", cartVM);
        }
    }
}
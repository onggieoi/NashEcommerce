using System.Threading.Tasks;
using System.Collections.Generic;
using client.Constants;
using client.Models;
using Microsoft.AspNetCore.Http;
using ViewModelShare.CartOrder;
using client.Extensions;

namespace client.Services.Cart
{
    public class CartService : ICartService
    {
        private readonly IHttpContextAccessor _httpContext;

        public CartService(IHttpContextAccessor httpContext)
        {
            _httpContext = httpContext;
        }
        public async Task<IEnumerable<CartOrderRespone>> AddOrder(CartOrderRespone cartOrder)
        {
            var orders = await GetCart() as List<CartOrderRespone>;

            if (orders is null)
            {
                orders = new List<CartOrderRespone>();
            }

            var existProduct = orders.Find(orders => orders.Product.ProductId.Equals(cartOrder.Product.ProductId));

            if (existProduct is not null)
            {
                cartOrder.Quantity += existProduct.Quantity;
                orders.Remove(existProduct);
            }

            orders.Add(cartOrder);

            await SetCart(orders);

            return orders;
        }

        public async Task Remove(int productId)
        {
            var orders = await GetCart() as List<CartOrderRespone>;

            var index = orders.FindIndex(order => order.Product.ProductId.Equals(productId));

            orders.RemoveAt(index);

            await SetCart(orders);

            await Task.CompletedTask;
        }

        public async Task<CartViewModel> GetCartViewModel()
        {
            var orders = await GetCart() as List<CartOrderRespone>;

            var count = 0;
            var total = 0;

            orders?.ForEach(order =>
            {
                count += order.Quantity;
                total += order.Quantity * order.Product.Price;
            });

            return new CartViewModel
            {
                Total = total,
                Count = count,
                Orders = orders
            };
        }

        public async Task Clear()
        {
            _httpContext.HttpContext.Session.Remove(SessionKeys.Cart);
            await Task.CompletedTask;
        }

        private async Task<IEnumerable<CartOrderRespone>> GetCart() =>
            await Task.FromResult(_httpContext.HttpContext.Session.GetObject<IEnumerable<CartOrderRespone>>(SessionKeys.Cart));

        private async Task SetCart(IEnumerable<CartOrderRespone> orders)
        {
            _httpContext.HttpContext.Session.SetObject<IEnumerable<CartOrderRespone>>(SessionKeys.Cart, orders);
            await Task.CompletedTask;
        }
    }
}
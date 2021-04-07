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
        public IEnumerable<CartOrderRespone> AddOrder(CartOrderRespone cartOrder)
        {
            var orders = GetCart() as List<CartOrderRespone>;

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

            SetCart(orders);

            return orders;
        }

        public void Remove(int productId)
        {
            var orders = GetCart() as List<CartOrderRespone>;

            var index = orders.FindIndex(order => order.Product.ProductId.Equals(productId));

            orders.RemoveAt(index);

            SetCart(orders);

            // return GetCartViewModel();
        }

        public CartViewModel GetCartViewModel()
        {
            var orders = GetCart() as List<CartOrderRespone>;

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

        public void Clear()
        {
            _httpContext.HttpContext.Session.Remove(SessionKeys.Cart);
        }

        private IEnumerable<CartOrderRespone> GetCart() =>
            _httpContext.HttpContext.Session.GetObject<IEnumerable<CartOrderRespone>>(SessionKeys.Cart);

        private void SetCart(IEnumerable<CartOrderRespone> orders) =>
            _httpContext.HttpContext.Session.SetObject<IEnumerable<CartOrderRespone>>(SessionKeys.Cart, orders);
    }
}
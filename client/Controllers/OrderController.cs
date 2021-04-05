using System.Collections.Generic;
using System.Threading.Tasks;
using client.Constants;
using client.Extensions;
using client.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ViewModelShare.CartOrder;

namespace client.Controllers
{
    public class OrderController : Controller
    {
        private readonly IHttpClientService _client;

        public OrderController(IHttpClientService client)
        {
            _client = client;
        }

        public IActionResult Index()
        {
            var cart = HttpContext.Session.GetObject<IEnumerable<CartOrderRequest>>(SessionKeys.Cart);

            return View(cart);
        }

        [HttpPost("[controller]/{productId}")]
        public IActionResult AddProduct(int productId, int quantity)
        {
            var cartOrder = new CartOrderRequest
            {
                ProductId = productId,
                Quantity = quantity
            };

            AddOrder(productId, quantity);

            // return Ok(true);
            return RedirectToAction("Index", "Home");
        }

        [Authorize]
        [HttpPost("[controller]")]
        public async Task<IActionResult> CreateOrder(int productId, int quantity)
        {
            var result = await _client.Order(productId, quantity);

            if (result is null)
            {
                return Content("false");
            }

            return RedirectToAction("Index", "Home");
        }

        private void AddOrder(int productId, int quantity)
        {
            var cartOrder = new CartOrderRequest
            {
                ProductId = productId,
                Quantity = quantity
            };

            var orders = HttpContext.Session.GetObject<IEnumerable<CartOrderRequest>>(SessionKeys.Cart) as List<CartOrderRequest>;

            if (orders is null)
            {
                orders = new List<CartOrderRequest>();
            }

            orders.Add(cartOrder);

            HttpContext.Session.SetObject<IEnumerable<CartOrderRequest>>(SessionKeys.Cart, orders);
        }
    }
}
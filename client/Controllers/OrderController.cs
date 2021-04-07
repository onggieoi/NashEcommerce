using System.Collections.Generic;
using System.Threading.Tasks;
using client.Constants;
using client.Models;
using client.Services;
using client.Services.Cart;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ViewModelShare.CartOrder;
using ViewModelShare.Product;

namespace client.Controllers
{
    public class OrderController : Controller
    {
        private readonly ICartService _cartService;
        private readonly IHttpClientService _client;

        public OrderController(IHttpClientService client,
            ICartService cartService)
        {
            _cartService = cartService;
            _client = client;
        }

        public async Task<ActionResult<CartViewModel>> Index()
        {
            var cartVM = await _cartService.GetCartViewModel();

            return View(cartVM);
        }

        [HttpPost("[controller]/{productId}")]
        public async Task<ActionResult<IEnumerable<CartOrderRequest>>> AddProduct(
            int productId, int quantity, ProductRespone product)
        {
            var cartOrder = new CartOrderRespone
            {
                Product = product,
                Quantity = quantity
            };

            var orders = await _cartService.AddOrder(cartOrder);

            return Ok(orders);
        }

        public async Task<ActionResult<IEnumerable<CartOrderRequest>>> Remove(int productId)
        {
            await _cartService.Remove(productId);

            return RedirectToAction("Index");
        }

        [Authorize]
        [HttpPost("[controller]")]
        public async Task<IActionResult> CreateOrder()
        {
            var result = await _client.Order();

            if (result is null)
            {
                return View("OrderResult", false);
            }

            await _cartService.Clear();

            return View("OrderResult", true);
        }
    }
}
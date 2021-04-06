using System.Collections.Generic;
using System.Threading.Tasks;
using client.Constants;
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

        public IActionResult Index()
        {
            var cartVM = _cartService.GetCartViewModel();

            return View(cartVM);
        }

        [HttpPost("[controller]/{productId}")]
        public ActionResult<IEnumerable<CartOrderRequest>> AddProduct(int productId, int quantity, ProductRespone product)
        {
            var cartOrder = new CartOrderRespone
            {
                Product = product,
                Quantity = quantity
            };

            var orders = _cartService.AddOrder(cartOrder);

            return Ok(orders);
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

            _cartService.Clear();

            return View("OrderResult", true);
        }
    }
}
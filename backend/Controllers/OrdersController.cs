using System.Collections.Generic;
using System.Threading.Tasks;
using backend.Constans;
using backend.Repositories.OrderCartRepo;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ViewModelShare.CartOrder;

namespace backend.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class OrdersController : ControllerBase
    {
        private readonly IOrderCartRepository _orderCart;

        public OrdersController(IOrderCartRepository orderCartRepository)
        {
            _orderCart = orderCartRepository;
        }

        [Authorize("Bearer")]
        [HttpPost]
        public async Task<ActionResult<IEnumerable<CartOrderRespone>>> CreateOrder(IEnumerable<CartOrderRequest> cartOrdersRequest)
        {
            var cart = await _orderCart.CreateOrder(cartOrdersRequest);

            var cartOrderRespones = await _orderCart.GetOrders(cart.Id);

            return Created(Endpoints.Order, cartOrderRespones);
        }

        [Authorize("Admin")]
        [HttpGet("{cartId}")]
        public async Task<ActionResult<IEnumerable<CartOrderRespone>>> GetOrder(int cartId)
        {
            var cartOrderRespones = await _orderCart.GetOrders(cartId);

            return Ok(cartOrderRespones);
        }
    }
}
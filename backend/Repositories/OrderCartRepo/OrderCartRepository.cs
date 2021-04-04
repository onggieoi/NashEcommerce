using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using backend.DbContexts;
using backend.Models;
using ViewModelShare.CartOrder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Microsoft.AspNetCore.Http;
using System.Security.Claims;

namespace backend.Repositories.OrderCartRepo
{
    public class OrderCartRepository : IOrderCartRepository
    {
        private readonly ILogger<OrderCartRepository> _logger;
        private readonly IMapper _mapper;
        private readonly ApplicationDbContext _context;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public OrderCartRepository(ILogger<OrderCartRepository> logger,
            IHttpContextAccessor httpContextAccessor,
            IMapper mapper,
            ApplicationDbContext context)
        {
            _logger = logger;
            _mapper = mapper;
            _context = context;
            _httpContextAccessor = httpContextAccessor;
        }
        public async Task<Cart> CreateOrder(IEnumerable<CartOrderRequest> cartOrdersRequest)
        {
            var cartDetails = _mapper.Map<List<CartDetail>>(cartOrdersRequest);

            var userId = _httpContextAccessor.HttpContext.User.FindFirstValue("sub");

            var cart = new Cart
            {
                UserId = userId
            };

            var newCart = await _context.Carts.AddAsync(cart);
            await _context.SaveChangesAsync();

            cartDetails.ForEach(cartDetail =>
            {
                cartDetail.CartId = cart.Id;
            });

            await _context.CartDetails.AddRangeAsync(cartDetails);

            await _context.SaveChangesAsync();

            return cart;
        }

        public async Task<IEnumerable<CartOrderRespone>> GetOrders(int orderId)
        {
            var cartDetails = await _context.CartDetails
                .Include(cartDetail => cartDetail.Product)
                .Where(cartDetail => cartDetail.CartId.Equals(orderId))
                .ToListAsync();

            var cartOrderRespones = _mapper.Map<IEnumerable<CartOrderRespone>>(cartDetails);

            return cartOrderRespones;
        }
    }
}
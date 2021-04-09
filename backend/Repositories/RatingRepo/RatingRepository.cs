using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using AutoMapper;
using backend.DbContexts;
using backend.Models;
using Microsoft.AspNetCore.Http;
using ViewModelShare.Rate;

namespace backend.Repositories.RatingRepo
{
    public class RatingRepository : IRatingRepository
    {
        private readonly IMapper _mapper;
        private readonly ApplicationDbContext _context;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public RatingRepository(IMapper mapper,
            IHttpContextAccessor httpContextAccessor,
            ApplicationDbContext context)
        {
            _mapper = mapper;
            _context = context;
            _httpContextAccessor = httpContextAccessor;
        }
        public async Task<bool> Create(RateRequest rateRequest)
        {
            var rate = _mapper.Map<Rate>(rateRequest);

            var userId = _httpContextAccessor.HttpContext.User.FindFirstValue("sub");

            rate.UserId = userId;

            await _context.AddAsync(rate);
            await _context.SaveChangesAsync();

            var product = await _context.Products.FindAsync(rateRequest.ProductId);

            var rates = await Task.FromResult((int)_context.Rates
                .Where(rate => rate.ProductId.Equals(rateRequest.ProductId))
                .Select(rate => rate.Value)
                .Average());

            product.Rated = rates;
            await _context.SaveChangesAsync();

            return true;
        }
    }
}
using System.Threading.Tasks;
using AutoMapper;
using backend.DbContexts;
using backend.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;
using ViewModelShare.Product;

namespace backend.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProductsController : ControllerBase
    {
        private ILogger<ProductsController> _logger;
        private ApplicationDbContext _context;
        private IMapper _mapper;

        public ProductsController(
            ILogger<ProductsController> logger,
            IMapper mapper,
            ApplicationDbContext context)
        {
            _logger = logger;
            _context = context;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> GetProducts()
        {
            var products = await _context.Products
                .Include(products => products.Category)
                .AsNoTracking()
                .ToListAsync();

            var productsRes = _mapper.Map<List<ProductRespone>>(products);

            return Ok(productsRes);
        }

        [HttpPost]
        public async Task<IActionResult> CreateProduct([FromBody] ProductRequest productReq)
        {
            var product = _mapper.Map<Product>(productReq);

            await _context.Products.AddAsync(product);
            await _context.SaveChangesAsync();

            var productRes = _mapper.Map<ProductRespone>(product);

            return Ok(productRes);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> RemoveProduct(int id)
        {
            var product = await _context.Products.FindAsync(id);

            if (product == null) return NotFound(new { message = $"Product id {id} not found" });

            product.IsDelete = true;
            await _context.SaveChangesAsync();

            var productRes = _mapper.Map<ProductRespone>(product);

            return Ok(productRes);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateProduct(int id, ProductRequest productReq)
        {
            var existProduct = await _context.Products.FindAsync(id);

            if (existProduct == null) return NotFound(new { message = $"Product id {id} not found" });

            _context.Entry<Product>(existProduct).CurrentValues.SetValues(productReq);

            await _context.SaveChangesAsync();

            var productRes = _mapper.Map<ProductRespone>(existProduct);

            return Ok(productRes);
        }
    }
}
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using backend.DbContexts;
using backend.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using ViewModelShare.Category;

namespace backend.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CategoriesController : Controller
    {
        private ILogger<CategoriesController> _logger;
        private ApplicationDbContext _context;
        private IMapper _mapper;

        public CategoriesController(
            ILogger<CategoriesController> logger,
            IMapper mapper,
            ApplicationDbContext context)
        {
            _logger = logger;
            _context = context;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<CategoryRespone>>> GetAll()
        {
            var categoriesWithProducts = await _context.Categories
                .Include(c => c.Products.Take(3))
                .AsNoTracking()
                .ToListAsync();

            var categoryRespone = _mapper.Map<IEnumerable<CategoryRespone>>(categoriesWithProducts);

            return Ok(categoryRespone);
        }

        [HttpPost]
        public async Task<ActionResult<CategoryRespone>> Create([FromBody] CategoryRequest request)
        {
            var newCategory = _mapper.Map<Category>(request);

            await _context.Categories.AddAsync(newCategory);
            await _context.SaveChangesAsync();

            var createdCategory = _mapper.Map<CategoryRespone>(newCategory);

            return Ok(createdCategory);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<CategoryRespone>> Remove(int id)
        {
            var category = await _context.Categories.FindAsync(id);

            if (category == null) return NotFound(new { message = $"Product id {id} not found" });

            category.IsDelete = true;
            await _context.SaveChangesAsync();

            return Ok(category);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<CategoryRespone>> Update(int id, CategoryRequest request)
        {
            var existCategory = await _context.Categories.FindAsync(id);

            if (existCategory == null) return NotFound(new { message = $"Product id {id} not found" });

            _context.Entry<Category>(existCategory).CurrentValues.SetValues(request);
            await _context.SaveChangesAsync();

            var updatedCategory = _mapper.Map<CategoryRespone>(existCategory);

            return Ok(updatedCategory);
        }
    }
}
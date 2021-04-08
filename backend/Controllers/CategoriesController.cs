using System.Collections.Generic;
using System.Threading.Tasks;
using backend.Constans;
using backend.Repositories.CategoryRepo;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using ViewModelShare.Category;

namespace backend.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CategoriesController : ControllerBase
    {
        private ILogger<CategoriesController> _logger;
        private ICategoryRepository _categoryRepository;

        public CategoriesController(
            ILogger<CategoriesController> logger,
            ICategoryRepository categoryRepository)
        {
            _logger = logger;
            _categoryRepository = categoryRepository;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<CategoryRespone>>> GetAll()
        {
            var categoryRespone = await _categoryRepository.GetCategories();
            return Ok(categoryRespone);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<CategoryRespone>> GetById(int id)
        {
            var categoryRespone = await _categoryRepository.GetById(id);
            return Ok(categoryRespone);
        }

        [HttpPost]
        public async Task<ActionResult<CategoryRespone>> Create([FromBody] CategoryRequest request)
        {
            var createdCategory = await _categoryRepository.Create(request);

            return Created(Endpoints.Category, createdCategory);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<CategoryRespone>> Delete(int id)
        {
            var categoryRespone = await _categoryRepository.Delete(id);

            return Ok(categoryRespone);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<CategoryRespone>> Update(int id, CategoryRequest request)
        {
            var updatedCategory = await _categoryRepository.Update(id, request);

            return Ok(updatedCategory);
        }
    }
}
using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using backend.Repositories.CategoryRepo;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using ViewModelShare.Category;

namespace backend.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CategoriesController : Controller
    {
        private ILogger<CategoriesController> _logger;
        private IMapper _mapper;
        private ICategoryRepository _categoryRepository;

        public CategoriesController(
            ILogger<CategoriesController> logger,
            IMapper mapper,
            ICategoryRepository categoryRepository)
        {
            _logger = logger;
            _mapper = mapper;
            _categoryRepository = categoryRepository;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<CategoryRespone>>> GetAll()
        {
            var categoryRespone = await _categoryRepository.GetCategories();
            return Ok(categoryRespone);
        }

        [HttpPost]
        public async Task<ActionResult<CategoryRespone>> Create([FromBody] CategoryRequest request)
        {
            var createdCategory = await _categoryRepository.Create(request);

            return Ok(createdCategory);
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
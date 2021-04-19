using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;
using ViewModelShare.Product;
using backend.Repositories.ProductRepo;
using backend.Constans;
using Microsoft.AspNetCore.Authorization;

namespace backend.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProductsController : ControllerBase
    {
        private ILogger<ProductsController> _logger;
        private IProductRepository _productRepository;

        public ProductsController(
            ILogger<ProductsController> logger,
            IProductRepository productRepository)
        {
            _logger = logger;
            _productRepository = productRepository;
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ProductRespone>> GetProduct(int id)
        {
            var result = await _productRepository.GetProduct(id);
            return Ok(result);
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<ProductRespone>>> GetProducts(int? categoryId)
        {
            if (categoryId is null)
            {
                var products = await _productRepository.GetProducts();

                return Ok(products);
            }

            var productsByCategory = await _productRepository.GetProductsByCategory(categoryId.Value);

            return Ok(productsByCategory);
        }

        [Authorize("Admin")]
        [HttpPost]
        public async Task<ActionResult<ProductRespone>> CreateProduct([FromForm] ProductRequest productReq)
        {
            var product = await _productRepository.CreateProduct(productReq);

            return Created(Endpoints.Product, product);
        }

        [Authorize("Admin")]
        [HttpDelete("{id}")]
        public async Task<ActionResult<ProductRespone>> RemoveProduct(int id)
        {
            var productRes = await _productRepository.DeleteProduct(id);

            return Ok(productRes);
        }

        [Authorize("Admin")]
        [HttpPut("{id}")]
        public async Task<ActionResult<ProductRespone>> UpdateProduct(int id, [FromForm] ProductRequest productReq)
        {
            var productRes = await _productRepository.UpdateProduct(id, productReq);

            return Ok(productRes);
        }
    }
}
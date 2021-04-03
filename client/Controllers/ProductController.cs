using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using client.Services;
using Microsoft.AspNetCore.Mvc;
using ViewModelShare.Product;

namespace client.Controllers
{
    public class ProductController : Controller
    {
        private IHttpClientService _client;

        public ProductController(IHttpClientService client)
        {
            _client = client;
        }

        [HttpGet("[controller]/{id}")]
        public async Task<ActionResult<ProductRespone>> Detail(int id)
        {
            var product = await _client.GetProductById(id);

            return View(product);
        }

        public async Task<ActionResult<IEnumerable<ProductRespone>>> Index(int? categoryId)
        {
            if (categoryId is null)
            {
                throw new NotImplementedException();
            }

            var products = await _client.GetProductsByCategory(categoryId.Value);

            return View(products);
        }
    }
}
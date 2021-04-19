using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using client.Services;
using Microsoft.AspNetCore.Authorization;
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
            IEnumerable<ProductRespone> products;

            if (categoryId is null)
            {
                products = await _client.GetProducts();
            }
            else
            {
                products = await _client.GetProductsByCategory(categoryId.Value);
            }


            return View(products);
        }

        [Authorize]
        [HttpPost("[controller]/{id}")]
        public async Task<IActionResult> Voting(int id, int rating)
        {
            var result = await _client.Voting(id, rating);

            if (result is false)
            {
                return Content("false");
            }

            return RedirectToAction("Index", "Home");
        }
    }
}
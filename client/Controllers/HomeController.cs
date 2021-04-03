using System.Diagnostics;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

using client.Models;
using client.Services;
using System.Collections.Generic;
using ViewModelShare.Category;

namespace client.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IHttpClientService _client;

        public HomeController(ILogger<HomeController> logger,
            IHttpClientService client)
        {
            _logger = logger;
            _client = client;
        }

        public async Task<ActionResult<IEnumerable<CategoryRespone>>> Index()
        {
            var categories = await _client.GetCategories();

            return View(categories);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}

using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using client.Constants;
using client.Services.Cart;
using Microsoft.Extensions.Caching.Memory;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using ViewModelShare.CartOrder;
using ViewModelShare.Category;
using ViewModelShare.Product;
using ViewModelShare.Rate;

namespace client.Services
{
    public class HttpClientService : IHttpClientService
    {
        private readonly ICartService _cartService;
        private HttpClient _client;
        private IMemoryCache _memoryCache;
        private ILogger _logger;

        public HttpClientService(HttpClient client,
            ILogger<HttpClientService> logger,
            ICartService cartService,
            IMemoryCache memoryCache)
        {
            _cartService = cartService;
            _client = client;
            _memoryCache = memoryCache;
            _logger = logger;
        }

        public async Task<IEnumerable<CategoryRespone>> GetCategories()
        {
            var categories = await _memoryCache
                .GetOrCreateAsync(CacheKeys.CacheCategoriesWithProduct, async entry =>
                {
                    _logger.LogInformation("create CategoriesWithProducts Cached!");

                    var res = await _client.GetAsync(EndPoints.Category);

                    res.EnsureSuccessStatusCode();

                    var categoryRespones = await res.Content.ReadAsAsync<IEnumerable<CategoryRespone>>();

                    entry.SlidingExpiration = TimeSpan.FromHours(1);
                    entry.SetValue(categoryRespones);

                    return categoryRespones;
                });

            return categories;
        }

        public async Task<ProductRespone> GetProductById(int productId)
        {
            var res = await _client.GetAsync(EndPoints.GetProductById(productId));

            res.EnsureSuccessStatusCode();

            var product = await res.Content.ReadAsAsync<ProductRespone>();

            return product;
        }

        public async Task<IEnumerable<ProductRespone>> GetProducts()
        {
            var res = await _client.GetAsync(EndPoints.Product);

            res.EnsureSuccessStatusCode();

            var products = await res.Content.ReadAsAsync<IEnumerable<ProductRespone>>();

            return products;
        }

        public async Task<IEnumerable<ProductRespone>> GetProductsByCategory(int categoryId)
        {
            var res = await _client.GetAsync(EndPoints.GetProductByCategory(categoryId));

            res.EnsureSuccessStatusCode();

            var products = await res.Content.ReadAsAsync<IEnumerable<ProductRespone>>();

            return products;
        }

        public async Task<bool> Voting(int productId, int voting)
        {
            var rateRequest = new RateRequest
            {
                ProductId = productId,
                Value = voting
            };

            var json = JsonConvert.SerializeObject(rateRequest);
            var data = new StringContent(json, Encoding.UTF8, "application/json");

            var res = await _client.PostAsync(EndPoints.Rate, data);

            res.EnsureSuccessStatusCode();

            var result = await res.Content.ReadAsAsync<bool>();

            return result;
        }
        public async Task<IEnumerable<CartOrderRespone>> Order()
        {
            var request = new List<CartOrderRequest>();

            var cartVM = await _cartService.GetCartViewModel();
            var orders = cartVM.Orders as List<CartOrderRespone>;

            orders.ForEach(order =>
            {
                request.Add(new CartOrderRequest
                {
                    ProductId = order.Product.ProductId,
                    Quantity = order.Quantity,
                });
            });

            var json = JsonConvert.SerializeObject(request);
            var data = new StringContent(json, Encoding.UTF8, "application/json");

            var res = await _client.PostAsync(EndPoints.Order, data);

            res.EnsureSuccessStatusCode();

            var result = await res.Content.ReadAsAsync<IEnumerable<CartOrderRespone>>();

            return result;
        }
    }
}
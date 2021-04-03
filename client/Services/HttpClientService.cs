using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using client.Constants;
using Microsoft.Extensions.Caching.Memory;
using Microsoft.Extensions.Logging;
using ViewModelShare.Category;
using ViewModelShare.Product;

namespace client.Services
{
    public class HttpClientService : IHttpClientService
    {
        private HttpClient _client;
        private IMemoryCache _memoryCache;
        private ILogger _logger;

        public HttpClientService(HttpClient client,
            ILogger<HttpClientService> logger,
            IMemoryCache memoryCache)
        {
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

        public async Task<IEnumerable<ProductRespone>> GetProductsByCategory(int categoryId)
        {
            var res = await _client.GetAsync(EndPoints.GetProductByCategory(categoryId));

            res.EnsureSuccessStatusCode();

            var products = await res.Content.ReadAsAsync<IEnumerable<ProductRespone>>();

            return products;
        }
    }
}
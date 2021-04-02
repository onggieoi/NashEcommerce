using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using client.Constants;
using Microsoft.Extensions.Caching.Memory;
using ViewModelShare.Category;

namespace client.Services
{
    public class HttpClientService : IHttpClientService
    {
        private HttpClient _client;
        private IMemoryCache _memoryCache;

        public HttpClientService(HttpClient client,
            IMemoryCache memoryCache)
        {
            _client = client;
            _memoryCache = memoryCache;
        }

        public async Task<IEnumerable<CategoryRespone>> GetCategories()
        {
            var categoryRespones = await _memoryCache
                .GetOrCreateAsync(CacheKeys.CacheCategoriesWithProduct, async entry =>
                {
                    Console.WriteLine("create CategoriesWithProducts Cached!");

                    var res = await _client.GetAsync(EndPoints.GetCategories);

                    res.EnsureSuccessStatusCode();

                    var categoryRespones = await res.Content.ReadAsAsync<IEnumerable<CategoryRespone>>();

                    entry.SlidingExpiration = TimeSpan.FromHours(1);
                    entry.SetValue(categoryRespones);

                    return categoryRespones;
                });

            return categoryRespones;
        }
    }
}
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using ViewModelShare.Category;

namespace client.Services
{
    public class HttpClientService : IHttpClientService
    {
        private HttpClient _client;

        public HttpClientService(HttpClient client)
        {
            _client = client;
        }
        public async Task<IEnumerable<CategoryRespone>> GetCategories()
        {
            var res = await _client.GetAsync("api/categories");

            res.EnsureSuccessStatusCode();

            return await res.Content.ReadAsAsync<IEnumerable<CategoryRespone>>();
        }
    }
}
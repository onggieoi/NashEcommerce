using System.Collections.Generic;
using System.Threading.Tasks;
using ViewModelShare.Category;

namespace client.Services
{
    public interface IHttpClientService
    {
        Task<IEnumerable<CategoryRespone>> GetCategories();
    }
}
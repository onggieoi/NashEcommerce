using System.Collections.Generic;
using System.Threading.Tasks;
using ViewModelShare.Category;
using ViewModelShare.Product;

namespace client.Services
{
    public interface IHttpClientService
    {
        Task<IEnumerable<CategoryRespone>> GetCategories();

        Task<IEnumerable<ProductRespone>> GetProductsByCategory(int categoryId);

        Task<ProductRespone> GetProductById(int id);
    }
}
using System.Collections.Generic;
using System.Threading.Tasks;
using ViewModelShare.CartOrder;
using ViewModelShare.Category;
using ViewModelShare.Product;

namespace client.Services
{
    public interface IHttpClientService
    {
        Task<IEnumerable<CategoryRespone>> GetCategories();

        Task<IEnumerable<ProductRespone>> GetProductsByCategory(int categoryId);
        Task<IEnumerable<ProductRespone>> GetProducts();

        Task<ProductRespone> GetProductById(int id);

        Task<bool> Voting(int productId, int voting);
        Task<IEnumerable<CartOrderRespone>> Order();
    }
}
using System.Collections.Generic;
using System.Threading.Tasks;
using ViewModelShare.Product;

namespace backend.Repositories.ProductRepo
{
    public interface IProductRepository
    {
        Task<ProductRespone> GetProduct(int productId);

        Task<IEnumerable<ProductRespone>> GetProducts();

        Task<IEnumerable<ProductRespone>> GetProductsByCategory(int categoryId);

        Task<ProductRespone> CreateProduct(ProductRequest productReq);

        Task<ProductRespone> UpdateProduct(int productId, ProductRequest productReq);

        Task<ProductRespone> DeleteProduct(int productId);
    }
}
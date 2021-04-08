using System.Collections.Generic;
using System.Threading.Tasks;
using ViewModelShare.Category;

namespace backend.Repositories.CategoryRepo
{
    public interface ICategoryRepository
    {
        Task<IEnumerable<CategoryRespone>> GetCategories();
        Task<CategoryRespone> GetById(int id);

        Task<CategoryRespone> Create(CategoryRequest categoryRequest);

        Task<CategoryRespone> Update(int productId, CategoryRequest categoryRequest);

        Task<CategoryRespone> Delete(int categoryId);
    }
}
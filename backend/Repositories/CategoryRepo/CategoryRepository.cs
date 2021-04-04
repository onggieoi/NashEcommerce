using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using backend.DbContexts;
using backend.Exceptions;
using backend.Models;
using Microsoft.EntityFrameworkCore;
using ViewModelShare.Category;

namespace backend.Repositories.CategoryRepo
{
    public class CategoryRepository : ICategoryRepository
    {
        private IMapper _mapper;
        private ApplicationDbContext _context;

        public CategoryRepository(IMapper mapper,
            ApplicationDbContext context)
        {
            _mapper = mapper;
            _context = context;
        }

        public async Task<IEnumerable<CategoryRespone>> GetCategories()
        {
            var categoriesWithProducts = await _context.Categories
                .Include(c => c.Products.Take(3))
                .AsNoTracking()
                .ToListAsync();

            var categories = _mapper.Map<IEnumerable<CategoryRespone>>(categoriesWithProducts);

            return categories;
        }

        public async Task<CategoryRespone> Create(CategoryRequest categoryRequest)
        {
            var newCategory = _mapper.Map<Category>(categoryRequest);

            await _context.Categories.AddAsync(newCategory);
            await _context.SaveChangesAsync();

            var category = _mapper.Map<CategoryRespone>(newCategory);

            return category;
        }

        public async Task<CategoryRespone> Update(int categoryId, CategoryRequest categoryRequest)
        {
            var existCategory = await _context.Categories.FindAsync(categoryId);

            if (existCategory is null)
            {
                throw new NotFoundException($"categoryId {categoryId} not found");
            }
            _context.Entry<Category>(existCategory).CurrentValues.SetValues(categoryRequest);
            await _context.SaveChangesAsync();

            var updatedCategory = _mapper.Map<CategoryRespone>(existCategory);

            return updatedCategory;
        }

        public async Task<CategoryRespone> Delete(int categoryId)
        {
            var category = await _context.Categories.FindAsync(categoryId);

            if (category is null)
            {
                throw new NotFoundException($"categoryId {categoryId} not found");
            }

            category.IsDelete = true;
            await _context.SaveChangesAsync();

            var categoryRespone = _mapper.Map<CategoryRespone>(category);

            return categoryRespone;
        }
    }
}
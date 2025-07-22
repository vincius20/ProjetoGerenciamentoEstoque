using Entities;
using Microsoft.EntityFrameworkCore;
using ServicesContracts;
using ServicesContracts.DTO;
using Services.Helper;

namespace Services
{
    public class CategoriesService : ICategoriesService
    {
        private readonly StockDbContext _dbContext;

        public CategoriesService(StockDbContext stockDbContext)
        {
            _dbContext = stockDbContext;
        }
        public async Task<CategoryResponse> AddCategory(CategoryAddRequest? categoryAddRequest)
        {
            if (categoryAddRequest == null)
            {
                throw new ArgumentNullException(nameof(categoryAddRequest));
            }

            if (categoryAddRequest.CategoryName == null)
            {
                throw new ArgumentException(nameof(categoryAddRequest.CategoryName));
            }

            if (await _dbContext.Categories.CountAsync(temp => temp.CategoryName == categoryAddRequest.CategoryName) > 0)
            {
                throw new ArgumentException("Given category name already exists");
            }

            //Validation of the model
            ValidationHelper.ModelValidation(categoryAddRequest);

            Category category = categoryAddRequest.ToCategory();

            category.CategoryId = Guid.NewGuid();
            _dbContext.Categories.Add(category);
            await _dbContext.SaveChangesAsync();

            return category.ToCategoryResponse();
        }

        public async Task<bool> DeleteCategory(Guid? categoryId)
        {
            if (categoryId == null)
            {
                throw new ArgumentNullException(nameof(categoryId));
            }

            Category? category = await _dbContext.Categories.FirstOrDefaultAsync(temp => temp.CategoryId == categoryId);
            
            if (category == null)
            {
                return false;
            }

            _dbContext.Categories.Remove(_dbContext.Categories.FirstOrDefault(temp => temp.CategoryId == categoryId)!);
            await _dbContext.SaveChangesAsync();

            return true;
        }

        public async Task<List<CategoryResponse>?> GetAllCategories()
        {
            var categories = await _dbContext.Categories.Include("Products").ToListAsync();
            if (categories.Any())
            {
                return categories.Select(category => category.ToCategoryResponse()).ToList();
            }

            return null;
        }

        public async Task<CategoryResponse?> GetCategoryById(Guid? categoryId)
        {
            if(categoryId == null)
            {
                return null;
            }

            Category? category = await _dbContext.Categories.Include("Products")
                .FirstOrDefaultAsync(category => category.CategoryId == categoryId);

            if(category == null)
            {
                return null;
            }

            return category.ToCategoryResponse();
        }

        public async Task<CategoryResponse?> GetCategoryByName(string? categoryName)
        {
            if(categoryName == null)
            {
                return null;
            }

            var category = await _dbContext.Categories.Include("Products").ToListAsync();

            var result = category.FirstOrDefault(cat => cat.CategoryName.Contains(categoryName));

            return result?.ToCategoryResponse();
        }
    }
}

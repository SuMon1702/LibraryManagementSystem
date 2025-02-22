using LibraryManagementSystem.LibraryManagement.Utlis;
using LibraryManagementSystem.Models;
using LibraryManagementSystem.Repositories;

namespace LibraryManagementSystem.Services
{
    public class CategoryService : ICategoryService
    {
        private readonly ICategoryRepository _categoryRepository;

        public CategoryService(ICategoryRepository categoryRepository)
        {
            _categoryRepository = categoryRepository;
        }

        public async Task<Result<List<TblCategory>>> GetCategoryAsync()
        {
            var category = await _categoryRepository.GetCategoryAsync();
            return Result<List<TblCategory>>.Success(category.Data!);

        }
    }
}

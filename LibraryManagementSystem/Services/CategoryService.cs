using LibraryManagementSystem.LibraryManagement.Utlis;
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

        public async Task<Result<List<TblCategory>>> GetCategoryAsync(CancellationToken cs)
        {
            var category = await _categoryRepository.GetCategoryAsync(cs);
            return Result<List<TblCategory>>.Success(category.Data!);

        }
        public async Task<Result<TblCategory>> GetCategoryById(int id)
        {
            var category = await _categoryRepository.GetCategoryById(id);
            return Result<TblCategory>.Success(category.Data!);
        }
    }
}

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
        public async Task<Result<TblCategory>> GetCategoryByIdAsync(int id)
        {
            var category = await _categoryRepository.GetCategoryByIdAsync(id);
            return Result<TblCategory>.Success(category.Data!);
        }
    }
}

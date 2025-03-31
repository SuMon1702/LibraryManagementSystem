namespace LibraryManagementSystem.Repositories.Implementations
{
    public class CategoryRepository : ICategoryRepository
    {
        private readonly AppDbContext _context;

        public CategoryRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<Result<List<TblCategory?>>> GetCategoryAsync(CancellationToken cs)
        {
            var category = await _context.TblCategories.ToListAsync(cs);
            return Result<List<TblCategory?>>.Success(category!);
        }

        public async Task<Result<TblCategory?>> GetCategoryByIdAsync(int id)
        {
            var category = await _context.TblCategories.FirstOrDefaultAsync(x => x.CategoryId == id);
            if (category is null)
            {
                return Result<TblCategory?>.Fail("Category not found.");
            }
            return Result<TblCategory?>.Success(category);
        }
    }
}

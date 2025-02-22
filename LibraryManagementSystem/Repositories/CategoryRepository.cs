using LibraryManagementSystem.LibraryManagement.Utlis;
using LibraryManagementSystem.Models;
using Microsoft.EntityFrameworkCore;

namespace LibraryManagementSystem.Repositories
{
    public class CategoryRepository : ICategoryRepository
    {
        private readonly AppDbContext _context;

        public CategoryRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<Result<List<TblCategory?>>> GetCategoryAsync()
        {
            var category = await _context.TblCategories.ToListAsync();
            return Result<List<TblCategory?>>.Success(category!);
        }
    }
}

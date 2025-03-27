using LibraryManagementSystem.LibraryManagement.Utlis;
using LibraryManagementSystem.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace LibraryManagementSystem.Repositories.Implementations
{
    public class BookRepository : IBookRepository
    {
        private readonly AppDbContext _context;

        public BookRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<Result<List<TblBook?>>> GetAllBooksAsync(CancellationToken cs)
        {
            var item = await _context.TblBooks.ToListAsync(cs);

            if (item is null)
            {
                return Result<List<TblBook?>>.Fail("No data found.");

            }
            return Result<List<TblBook?>>.Success(item!, "Success");
        }

        public async Task<Result<TblBook?>> GetBookByIdAsync(int id)
        {
            var item = await _context.TblBooks.FirstOrDefaultAsync(x => x.BookId == id);
            if (item is null)
            {
                return Result<TblBook?>.Fail("No data found.");
            }
            return Result<TblBook?>.Success(item, "Success");
        }
    }
}

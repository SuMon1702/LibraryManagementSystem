using LibraryManagementSystem.LibraryManagement.Utlis;
using LibraryManagementSystem.Model;
using LibraryManagementSystem.Models;
using Microsoft.EntityFrameworkCore;

namespace LibraryManagementSystem.Repositories
{
    public class BookRepository : IBookRepository
    {
        private readonly AppDbContext _context;

        public BookRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<Result<List<TblBook?>>> GetAllBooksAsync()
        {
            var item = await _context.TblBooks.ToListAsync();
            
            if (item == null)
            {
                return Result<List<TblBook?>>.Fail("No data found.");

            }

            return Result<List<TblBook?>>.Success(item!, "Success");
        }

        public async Task<TblBook?> GetBookAsync(int id)
        {
            return await _context.TblBooks.FirstOrDefaultAsync(x => x.BookId == id && !x.IsActive);
        }




    }
}

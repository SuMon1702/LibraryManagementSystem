using LibraryManagementSystem.Models;
using Microsoft.EntityFrameworkCore;

namespace LibraryManagementSystem.Repositories
{
    public class BookRepository:IBookRepository
    {
        private readonly AppDbContext _context;

        public BookRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<List<TblBook>> GetAllBooksAsync(CancellationToken cs)
        {
            return await _context.TblBooks.Where(x => !x.IsActive).ToListAsync(cs);
        }

        public async Task<TblBook> GetBookAsync(int id)
        {
            return await _context.TblBooks.FindAsync(id);
        }
    }
}

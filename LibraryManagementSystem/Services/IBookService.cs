using LibraryManagementSystem.LibraryManagement.Utlis;
using LibraryManagementSystem.Model;
using LibraryManagementSystem.Models;

namespace LibraryManagementSystem.Services
{
    public interface IBookService
    {
        Task<Result<TblBook>> FindAsync(int id);
        Task<Result<List<TblBook>>> GetBooksAsync();
        Task<Result<TblBook>> CreateBook(BookRequestModel model);
        
    }
}

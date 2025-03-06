using LibraryManagementSystem.LibraryManagement.Utlis;
using LibraryManagementSystem.Model;
using LibraryManagementSystem.Models;

namespace LibraryManagementSystem.Services
{
    public interface IBookService
    {
       Task<Result<List<TblBook>>> GetAllBooksAsync();
       Task<Result<TblBook?>> GetBookAsync(int id);

    }
}

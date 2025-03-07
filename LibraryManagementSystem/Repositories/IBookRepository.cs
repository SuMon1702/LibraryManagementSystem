using LibraryManagementSystem.LibraryManagement.Utlis;
using LibraryManagementSystem.Models;

namespace LibraryManagementSystem.Repositories
{
    public interface IBookRepository
    {
       Task<Result<List<TblBook?>>> GetAllBooksAsync();
       Task<TblBook?> GetBookAsync(int id);
    }
}

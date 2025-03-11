using LibraryManagementSystem.LibraryManagement.Utlis;
using LibraryManagementSystem.Models;

namespace LibraryManagementSystem.Repositories
{
    public interface IBookRepository
    {
       Task<Result<List<TblBook?>>> GetAllBooksAsync(CancellationToken cs);
       Task<Result<TblBook?>> GetBookAsync(int id);
    }
}

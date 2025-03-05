using LibraryManagementSystem.LibraryManagement.Utlis;
using LibraryManagementSystem.Models;

namespace LibraryManagementSystem.Repositories
{
    public interface IBookRepository
    {
       Task<List<TblBook>> GetAllBooksAsync();

       //Task<TblBook?> GetBookAsync(int id, CancellationToken cs);
    }
}

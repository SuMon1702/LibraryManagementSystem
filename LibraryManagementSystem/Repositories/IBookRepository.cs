using LibraryManagementSystem.LibraryManagement.Utlis;

namespace LibraryManagementSystem.Repositories
{
    public interface IBookRepository
    {
       Task<Result<List<TblBook?>>> GetAllBooksAsync(CancellationToken cs);
       Task<Result<TblBook?>> GetBookAsync(int id);
    }
}

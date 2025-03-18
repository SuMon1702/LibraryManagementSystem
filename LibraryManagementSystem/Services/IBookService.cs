using LibraryManagementSystem.LibraryManagement.Utlis;

namespace LibraryManagementSystem.Services
{
    public interface IBookService
    {
       Task<Result<List<TblBook>>> GetAllBooksAsync(CancellationToken cs);
       Task<Result<TblBook?>> GetBookByIdAsync(int id);

    }
}

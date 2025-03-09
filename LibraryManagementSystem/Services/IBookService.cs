using LibraryManagementSystem.LibraryManagement.Utlis;

namespace LibraryManagementSystem.Services
{
    public interface IBookService
    {
       
       Task<Result<List<TblBook>>> GetAllBooksAsync();
       Task<Result<TblBook?>> GetBookAsync(int id);

    }
}

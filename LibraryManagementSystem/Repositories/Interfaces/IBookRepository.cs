namespace LibraryManagementSystem.Repositories.Interfaces;

public interface IBookRepository
{
    Task<Result<List<TblBook?>>> GetAllBooksAsync(CancellationToken cs);
    Task<Result<TblBook?>> GetBookByIdAsync(int id);
}

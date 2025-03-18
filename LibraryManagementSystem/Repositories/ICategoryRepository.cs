using LibraryManagementSystem.LibraryManagement.Utlis;

namespace LibraryManagementSystem.Repositories
{
    public interface ICategoryRepository
    {
        Task<Result<List<TblCategory?>>> GetCategoryAsync(CancellationToken cs);
        Task<Result<TblCategory?>> GetCategoryByIdAsync(int id);

    }
}

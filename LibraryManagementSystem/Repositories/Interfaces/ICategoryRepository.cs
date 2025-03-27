using LibraryManagementSystem.LibraryManagement.Utlis;

namespace LibraryManagementSystem.Repositories.Interfaces
{
    public interface ICategoryRepository
    {
        Task<Result<List<TblCategory?>>> GetCategoryAsync(CancellationToken cs);
        Task<Result<TblCategory?>> GetCategoryByIdAsync(int id);

    }
}

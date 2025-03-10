using LibraryManagementSystem.LibraryManagement.Utlis;
using LibraryManagementSystem.Models;

namespace LibraryManagementSystem.Repositories
{
    public interface ICategoryRepository
    {
        Task<Result<List<TblCategory?>>> GetCategoryAsync(CancellationToken cs);
        Task<Result<TblCategory?>> GetCategoryById(int id);

    }
}

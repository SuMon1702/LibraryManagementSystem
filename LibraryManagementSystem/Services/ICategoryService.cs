using LibraryManagementSystem.LibraryManagement.Utlis;

namespace LibraryManagementSystem.Services
{
    public interface ICategoryService
    {
        Task<Result<List<TblCategory>>> GetCategoryAsync(CancellationToken cs);
        Task<Result<TblCategory>> GetCategoryById(int id);
    }
}

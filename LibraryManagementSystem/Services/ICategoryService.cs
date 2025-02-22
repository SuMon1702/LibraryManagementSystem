using LibraryManagementSystem.LibraryManagement.Utlis;
using LibraryManagementSystem.Models;

namespace LibraryManagementSystem.Services
{
    public interface ICategoryService
    {
        Task<Result<List<TblCategory>>> GetCategoryAsync();
    }
}

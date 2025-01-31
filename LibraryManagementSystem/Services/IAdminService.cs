using LibraryManagementSystem.LibraryManagement.Utlis;
using LibraryManagementSystem.Models;

namespace LibraryManagementSystem.Services
{
    public interface IAdminService
    {
        Task<Result<List<TblAdmin>>> GetAdminsAsync();
        
    }
}

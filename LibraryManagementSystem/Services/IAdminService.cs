using LibraryManagementSystem.LibraryManagement.Utlis;
using LibraryManagementSystem.Model;
using LibraryManagementSystem.Models;

namespace LibraryManagementSystem.Services
{
    public interface IAdminService
    {
        Task<Result<List<TblAdmin>>> GetAdminsAsync();
        Task<Result<TblAdmin>> GetAdminByIdAsync(int id);
        Task<Result<TblAdmin>> AdminLogin(AdminLoginModel loginModel);
        Task<Result<TblAdmin>> UpdateAdmin(int id, AdminModel model);
    }
}

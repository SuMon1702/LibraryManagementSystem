using LibraryManagementSystem.Dtos;
using LibraryManagementSystem.LibraryManagement.Utlis;
using LibraryManagementSystem.Model;
using LibraryManagementSystem.Models;

namespace LibraryManagementSystem.Services
{
    public interface IAdminService
    {
        Task<Result<List<TblAdmin>>> GetAdminsAsync(CancellationToken cs);
        Task<Result<TblAdmin>> GetAdminByIdAsync(int id);
        Task<Result<TblAdmin>> AdminLogin(AdminLoginModel loginModel);
        Task<Result<TblAdmin>> UpdateAdmin(int id, AdminModel model);
        Task<Result<TblAdmin>> ResetPassword(int adminId, string newPassword);
    }
}

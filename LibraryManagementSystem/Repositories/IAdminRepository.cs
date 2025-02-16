using LibraryManagementSystem.Dtos;
using LibraryManagementSystem.LibraryManagement.Utlis;
using LibraryManagementSystem.Model;
using LibraryManagementSystem.Models;

namespace LibraryManagementSystem.Repositories
{
    public interface IAdminRepository
    {
        Task<Result<List<TblAdmin?>>> GetAdminsAsync();
        Task<Result<TblAdmin?>> GetAdminByIdAsync(int id);
        Task<Result<TblAdmin?>> AdminLogin(string email, string password);
        Task<Result<TblAdmin?>> UpdateAdmin(int id, AdminModel model);
        Task<Result<TblAdmin>> ResetPassword(int adminId,string newPassword);
    }
}

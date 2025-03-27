using LibraryManagementSystem.LibraryManagement.Utlis;
using LibraryManagementSystem.Model;

namespace LibraryManagementSystem.Repositories.Interfaces
{
    public interface IAdminRepository
    {
        Task<Result<List<TblAdmin?>>> GetAdminsAsync(CancellationToken cs);
        Task<Result<TblAdmin?>> GetAdminByIdAsync(int id);
        Task<Result<TblAdmin?>> AdminLogin(string email, string password);
        Task<Result<TblAdmin?>> UpdateAdmin(int id, AdminModel model);
        Task<Result<TblAdmin>> ResetPassword(int adminId, string newPassword);
    }
}

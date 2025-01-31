using LibraryManagementSystem.Models;

namespace LibraryManagementSystem.Repositories
{
    public interface IAdminRepository
    {
        Task<List<TblAdmin>> GetAdminsAsync();
        Task<TblAdmin?> GetAdminByIdAsync(int id);
        Task<TblAdmin?> AdminLogin(string email, string password);
    }
}

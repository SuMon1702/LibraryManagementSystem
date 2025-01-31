using LibraryManagementSystem.Models;

namespace LibraryManagementSystem.Repositories
{
    public interface IAdminRepository
    {
        Task<List<TblAdmin>> GetAdminsAsync();
        
    }
}

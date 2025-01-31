using LibraryManagementSystem.LibraryManagement.Utlis;
using LibraryManagementSystem.Models;
using LibraryManagementSystem.Repositories;

namespace LibraryManagementSystem.Services
{
    public class AdminService: IAdminService
    {
        private readonly IAdminRepository _adminRepository;

        public AdminService(IAdminRepository adminRepository)
        {
            _adminRepository = adminRepository;
        }

        public async Task<Result<List<TblAdmin>>> GetAdminsAsync()
        {
            var admins = await _adminRepository.GetAdminsAsync();
            return Result<List<TblAdmin>>.Success(admins);
        } 

       
    }

}

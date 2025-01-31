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

        public async Task<Result<TblAdmin>> GetAdminByIdAsync(int id)
        {
            var admin = await _adminRepository.GetAdminByIdAsync(id);
            if (admin == null)
            {
                return Result<TblAdmin>.Fail("Admin not found.");
            }
            return Result<TblAdmin>.Success(admin);
        }
    }

}

using LibraryManagementSystem.LibraryManagement.Utlis;
using LibraryManagementSystem.Model;
using LibraryManagementSystem.Models;
using LibraryManagementSystem.Repositories;

namespace LibraryManagementSystem.Services;

public class AdminService : IAdminService
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

    public async Task<Result<TblAdmin>> AdminLogin(AdminLoginModel loginModel)
    {
        if (loginModel == null)
        {
            return Result<TblAdmin>.Fail("Invalid Login");
        }

        if (string.IsNullOrWhiteSpace(loginModel.Email) || string.IsNullOrWhiteSpace(loginModel.Password))
        {
            return Result<TblAdmin>.Fail("Email and password fields cannot be empty.");
        }

        var admin = await _adminRepository.AdminLogin(loginModel.Email, loginModel.Password);

        if (admin == null)
        {
            return Result<TblAdmin>.Fail("Invalid email or password.");
        }
        return Result<TblAdmin>.Success(admin);
    }

    public async Task<Result<TblAdmin>> UpdateAdmin(int id, AdminModel model)
    {
        var item = await _adminRepository.UpdateAdmin(id,model);
        if (item == null)
        {
            return Result<TblAdmin>.Fail("Admin not found.");
        }
       return Result<TblAdmin>.Success(item);
    }

}

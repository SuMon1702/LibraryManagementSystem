using LibraryManagementSystem.LibraryManagement.Utlis;
using LibraryManagementSystem.Model;
using LibraryManagementSystem.Repositories;

namespace LibraryManagementSystem.Services;

public class AdminService : IAdminService
{
    private readonly IAdminRepository _adminRepository;

    public AdminService(IAdminRepository adminRepository)
    {
        _adminRepository = adminRepository;
    }

    public async Task<Result<List<TblAdmin>>> GetAdminsAsync(CancellationToken cs)
    {
        var admins = await _adminRepository.GetAdminsAsync(cs);
        return Result<List<TblAdmin>>.Success(admins.Data!,"Succeed");
    }

    public async Task<Result<TblAdmin>> GetAdminByIdAsync(int id)
    {
        var admin = await _adminRepository.GetAdminByIdAsync(id);
        if (admin == null)
        {
            return Result<TblAdmin>.Fail("Admin not found.");
        }
        return Result<TblAdmin>.Success("Succeed");
    }

    //public async Task<Result> GetAdminByIdAsync(int id)
    //{
    //    var admin = await _adminRepository.GetAdminByIdAsync(id);
    //    if (!admin.IsSuccess)
    //    {
    //        return Result.Fail("Admin not found.");
    //    }
    //    return Result.Success("Admin found successfully");
    //}


    public async Task<Result<TblAdmin>> AdminLogin(AdminLoginModel loginModel)
    {

        var admin = await _adminRepository.AdminLogin(loginModel.Email, loginModel.Password);

        if (!admin.IsSuccess)
        {
            return Result<TblAdmin>.Fail("Invalid email or password.");
        }

        return Result<TblAdmin>.Success("Admin Login is successful");
    }


    public async Task<Result<TblAdmin>> UpdateAdmin(int id, AdminModel model)
    {
        var item = await _adminRepository.UpdateAdmin(id,model);
        if (item == null)
        {
            return Result<TblAdmin>.Fail("Admin not found.");
        }
       return Result<TblAdmin>.Success("Admin updated");
    }

    public async Task<Result<TblAdmin>> ResetPassword(int adminId, string newPassword)
    {
        if (string.IsNullOrWhiteSpace(newPassword))
        {
            return Result<TblAdmin>.Fail("Password cannot be empty.");
        }
        var result = await _adminRepository.ResetPassword(adminId, newPassword);

        if (!result.IsSuccess)
        {
            return Result<TblAdmin>.Fail(result.Message!);  // Forward failure message from repository
        }

        return Result<TblAdmin>.Success("Password reset successful.");
    }


}

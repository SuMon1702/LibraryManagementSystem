using LibraryManagementSystem.LibraryManagement.Utlis;
using LibraryManagementSystem.Model;
using LibraryManagementSystem.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace LibraryManagementSystem.Repositories.Implementations;

public class AdminRepository : IAdminRepository
{
    private readonly AppDbContext _context;

    public AdminRepository(AppDbContext context)
    {
        _context = context;
    }

    public async Task<Result<List<TblAdmin?>>> GetAdminsAsync(CancellationToken cs)
    {
        var item = await _context.TblAdmins.ToListAsync(cs);

        if (item is null || item.Count == 0)
        {
            return Result<List<TblAdmin?>>.Fail("No data found.");
        }
        return Result<List<TblAdmin?>>.Success(item!, "Success");
    }

    public async Task<Result<TblAdmin?>> GetAdminByIdAsync(int id)
    {
        var result = await _context.TblAdmins.FirstOrDefaultAsync(x => x.AdminId == id);

        if (result is null)
        {
            return Result<TblAdmin?>.Fail("No data found");
        }
        return Result<TblAdmin?>.Success(result, "Data found");
    }

    public async Task<Result<TblAdmin?>> AdminLogin(string email, string password)
    {

        var admin = await _context.TblAdmins.FirstOrDefaultAsync(x => x.Email == email);

        if (admin is null)
        {
            return Result<TblAdmin?>.Fail("Invalid data");
        }

        //This step is to check if the stored password is hashed
        if (!admin.Password.StartsWith("$2a$") && !admin.Password.StartsWith("$2b$"))
        {

            admin.Password = BCrypt.Net.BCrypt.HashPassword(admin.Password);  // If NOT hashed, hash it and update the database

            _context.Entry(admin).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }

        // Verify the hashed password
        bool isPasswordValid = BCrypt.Net.BCrypt.Verify(password, admin.Password);

        if (!isPasswordValid)
        {
            return Result<TblAdmin?>.Fail("Invalid entry");
        }

        return Result<TblAdmin?>.Success(admin, "Admin login succeed");
    }

    public async Task<Result<TblAdmin?>> UpdateAdmin(int id, AdminModel model)
    {
        var admin = await _context.TblAdmins.FirstOrDefaultAsync(x => x.AdminId == id);
        if (admin is null)
        {
            return Result<TblAdmin?>.Fail("No data found");
        }

        //Only update fields that are provided (not null or empty)
        if (!string.IsNullOrWhiteSpace(model.AdminName))
        {
            admin.AdminName = model.AdminName;
        }

        if (!string.IsNullOrWhiteSpace(model.Address))
        {
            admin.Address = model.Address;
        }

        if (!string.IsNullOrWhiteSpace(model.Password))
        {
            admin.Password = BCrypt.Net.BCrypt.HashPassword(model.Password);
        }

        _context.Entry(admin).State = EntityState.Modified;
        await _context.SaveChangesAsync();

        return Result<TblAdmin?>.Success(admin);

    }

    public async Task<Result<TblAdmin>> ResetPassword(int adminId, string newPassword)
    {
        var admin = await _context.TblAdmins.FirstOrDefaultAsync(x => x.AdminId == adminId);
        if (admin == null)
        {
            return Result<TblAdmin>.Fail("Admin not found.");
        }

        // ✅ Hash the new password before saving
        admin.Password = BCrypt.Net.BCrypt.HashPassword(newPassword);

        _context.Entry(admin).State = EntityState.Modified;
        await _context.SaveChangesAsync();

        return Result<TblAdmin>.Success(admin, "Password reset successful.");
    }




}

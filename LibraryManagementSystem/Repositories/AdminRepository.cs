using LibraryManagementSystem.LibraryManagement.Utlis;
using LibraryManagementSystem.Model;
using LibraryManagementSystem.Models;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.CodeAnalysis.Scripting;
using Microsoft.EntityFrameworkCore;

namespace LibraryManagementSystem.Repositories
{
    public class AdminRepository : IAdminRepository
    {
        private readonly AppDbContext _context;

        public AdminRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<Result<List<TblAdmin?>>> GetAdminsAsync()
        {
            var item = await _context.TblAdmins.ToListAsync();

            if (item is null || item.Count == 0)
            {
                return Result<List<TblAdmin?>>.Fail("No data found.");
            }
            return Result<List<TblAdmin?>>.Success(item,"Success");
        }

        public async Task<Result<TblAdmin?>> GetAdminByIdAsync(int id)
        {
            var result=await _context.TblAdmins.FirstOrDefaultAsync(x => x.AdminId== id);
          
            return Result<TblAdmin?>.Success(result);
        }

        public async Task<Result<TblAdmin?>> AdminLogin (string email, string password)
        {
            // Fetch the admin by email
            var admin = await _context.TblAdmins.FirstOrDefaultAsync(x => x.Email == email);
            if (admin == null)
            {
                return Result<TblAdmin?>.Fail("Invalid email");
            }

            // Verify the hashed password
            bool isPasswordValid = BCrypt.Net.BCrypt.Verify(password, admin.Password);

            if (!isPasswordValid)
            {
                return Result<TblAdmin?>.Fail("Invalid password"); // Invalid password
            }

            return Result<TblAdmin?>.Success(admin,"Admin login succeed");
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

        
    }
}

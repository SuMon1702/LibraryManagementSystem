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

        public async Task<List<TblAdmin>> GetAdminsAsync()
        {
            return await _context.TblAdmins.ToListAsync();
        }

        public async Task<TblAdmin?> GetAdminByIdAsync(int id)
        {
            return await _context.TblAdmins.FirstOrDefaultAsync(x => x.AdminId== id);
        }

        public async Task<TblAdmin?> AdminLogin (string email, string password)
        {
            // Fetch the admin by email
            var admin = await _context.TblAdmins.FirstOrDefaultAsync(x => x.Email == email);


            // Verify the hashed password
            bool isPasswordValid = BCrypt.Net.BCrypt.Verify(password, admin.Password);

            if (!isPasswordValid)
            {
                return null; // Invalid password
            }

            return admin; // Return the admin if login is successful
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

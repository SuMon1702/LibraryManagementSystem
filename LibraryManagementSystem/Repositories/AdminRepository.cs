using LibraryManagementSystem.Model;
using LibraryManagementSystem.Models;
using Microsoft.AspNetCore.Http.HttpResults;
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
            return await _context.TblAdmins.FirstOrDefaultAsync(x => x.Email == email && x.Password == password);
        }

        public async Task<TblAdmin?> UpdateAdmin(int id, AdminModel model)
        {
            var admin = await _context.TblAdmins.FirstOrDefaultAsync(x => x.AdminId == id);
            if (admin == null)
            {
                return null;
            }
            admin.Address = model.Address;
            admin.AdminName = model.AdminName;

            _context.Entry(admin).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return admin;
        }

        
    }
}

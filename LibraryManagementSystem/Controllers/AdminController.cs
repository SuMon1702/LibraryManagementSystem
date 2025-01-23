using LibraryManagementSystem.LibraryManagement.Utlis;
using LibraryManagementSystem.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace LibraryManagementSystem.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AdminController : ControllerBase
    {

        private readonly AppDbContext _context;

        public AdminController(AppDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<Result<List<TblAdmin>>>> GetAdminsAsync()
        {
         
                var item = await _context.TblAdmins.ToListAsync();
                return Result<List<TblAdmin>>.Success(item);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Result<TblAdmin>>> GetAdminAsync (int id)
        {
            var item = await _context.TblAdmins.FirstOrDefaultAsync(x => x.AdminId == id);

            if (item is null)
            {
                return Result<TblAdmin>.Fail("No data is found");
            }

            return Result<TblAdmin>.Success(item);
        }
    }
}

using LibraryManagementSystem.LibraryManagement.Utlis;
using LibraryManagementSystem.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace LibraryManagementSystem.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MemberController : ControllerBase
    {
        private readonly AppDbContext _context;

        public MemberController(AppDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<Result<List<TblMember>>>> GetMembersAsync(CancellationToken cs)
        {
            var member= await _context.TblMembers.ToListAsync(cs);
            return Result<List<TblMember>>.Success(member);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Result<TblMember>>> GetMemberAsync(int id)
        {
            var member= await _context.TblCategories.FindAsync(id);
            if(member is null)
            {
                return Result<TblMember>.Fail("No member is found");
            }
            return Result<TblMember>.Success("Succeed");
        }
    }
}

using LibraryManagementSystem.LibraryManagement.Utlis;
using LibraryManagementSystem.Models;
using Microsoft.EntityFrameworkCore;

namespace LibraryManagementSystem.Repositories
{
    public class MemberRepository : IMemberRepository
    {
        private readonly AppDbContext _context;

        public MemberRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<Result<List<TblMember?>>> GetMembersAsync()
        {
            var members = await _context.TblMembers.ToListAsync();
            return Result<List<TblMember?>>.Success(members!);
        }
    }
}

using LibraryManagementSystem.LibraryManagement.Utlis;
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

        public async Task<Result<List<TblMember?>>> GetMembersAsync(CancellationToken cs)
        {
            var members = await _context.TblMembers.ToListAsync(cs);
            return Result<List<TblMember?>>.Success(members!);
        }

        public async Task<Result<TblMember?>> GetMemberByIDAsync(int id)
        {
            var members = await _context.TblMembers.FirstOrDefaultAsync(x => x.MemberId == id);
            if (members is null)
            {
                return Result<TblMember?>.Fail("No data found");
            }
            return Result<TblMember?>.Success(members);
        }
    }
}

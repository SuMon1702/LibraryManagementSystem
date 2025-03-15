using LibraryManagementSystem.LibraryManagement.Utlis;
using LibraryManagementSystem.Models;

namespace LibraryManagementSystem.Services
{
    public interface IMemberService
    {
        Task<Result<List<TblMember?>>> GetMembersAsync(CancellationToken cs);
        Task<Result<TblMember?>> GetMemberByIdAsync(int id);
    }
}

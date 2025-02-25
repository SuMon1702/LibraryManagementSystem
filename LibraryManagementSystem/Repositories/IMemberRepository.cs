using LibraryManagementSystem.LibraryManagement.Utlis;
using LibraryManagementSystem.Models;

namespace LibraryManagementSystem.Repositories
{
    public interface IMemberRepository
    {
        Task<Result<List<TblMember?>>> GetMembersAsync();
        Task<Result<TblMember?>> GetMemberByIDAsync(int id);
    }
}

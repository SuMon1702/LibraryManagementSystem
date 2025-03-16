using LibraryManagementSystem.LibraryManagement.Utlis;

namespace LibraryManagementSystem.Repositories
{
    public interface IMemberRepository
    {
        Task<Result<List<TblMember?>>> GetMembersAsync(CancellationToken cs);
        Task<Result<TblMember?>> GetMemberByIDAsync(int id);
    }
}

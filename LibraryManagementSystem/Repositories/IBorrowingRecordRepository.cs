using LibraryManagementSystem.LibraryManagement.Utlis;

namespace LibraryManagementSystem.Repositories
{
    public interface IBorrowingRecordRepository
    {
        Task<Result<List<TblBorrowingRecord>>> GetBorrowingRecordsAsync();
        Task<Result<TblBorrowingRecord?>> GetBorrowingRecordByIdAsync(int id);
    }
}
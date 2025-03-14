using LibraryManagementSystem.LibraryManagement.Utlis;

namespace LibraryManagementSystem.Services
{
    public interface IBorrowingRecordService
    {
        Task<Result<List<TblBorrowingRecord>>> GetBorrowingRecordsAsync(CancellationToken cs);
        Task<Result<TblBorrowingRecord?>> GetBorrowingRecordsByIdAsync(int id);

    }
}

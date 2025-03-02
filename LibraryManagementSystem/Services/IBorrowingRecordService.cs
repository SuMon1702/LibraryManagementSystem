using LibraryManagementSystem.LibraryManagement.Utlis;

namespace LibraryManagementSystem.Services
{
    public interface IBorrowingRecordService
    {
        Task<Result<List<TblBorrowingRecord>>> GetBorrowingRecordsAsync();
        Task<Result<List<TblBorrowingRecord>>> GetBorrowingRecordsByIdAsync();

    }
}

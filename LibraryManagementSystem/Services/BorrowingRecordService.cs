using LibraryManagementSystem.LibraryManagement.Utlis;
using LibraryManagementSystem.Repositories;

namespace LibraryManagementSystem.Services
{
    public class BorrowingRecordService : IBorrowingRecordService
    {
        private readonly IBorrowingRecordRepository _borrowingRecordRepository;

        public BorrowingRecordService(IBorrowingRecordRepository borrowingRecordRepository)
        {
            _borrowingRecordRepository = borrowingRecordRepository;
        }

        public async Task<Result<List<TblBorrowingRecord>>> GetBorrowingRecordsAsync()
        {
            return await _borrowingRecordRepository.GetBorrowingRecordsIdAsync();
        }

        public async Task<Result<List<TblBorrowingRecord>>> GetBorrowingRecordsByIdAsync()
        {
            return await _borrowingRecordRepository.GetBorrowingRecordsIdAsync();
        }
    }
}

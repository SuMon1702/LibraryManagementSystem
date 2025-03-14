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

        public async Task<Result<List<TblBorrowingRecord>>> GetBorrowingRecordsAsync(CancellationToken cs)
        {
            return await _borrowingRecordRepository.GetBorrowingRecordsAsync(cs);
        }

        public async Task<Result<TblBorrowingRecord?>> GetBorrowingRecordsByIdAsync(int id)
        {
            return await _borrowingRecordRepository.GetBorrowingRecordByIdAsync(id);
        }
    }
}

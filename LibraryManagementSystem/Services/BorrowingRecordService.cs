using LibraryManagementSystem.Repositories;

namespace LibraryManagementSystem.Services
{
    public class BorrowingRecordService
    {
        private readonly IBorrowingRecordRepository _borrowingRecordRepository;

        public BorrowingRecordService(IBorrowingRecordRepository borrowingRecordRepository)
        {
            _borrowingRecordRepository = borrowingRecordRepository;
        }
    }
}

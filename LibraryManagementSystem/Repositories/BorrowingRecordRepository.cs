using LibraryManagementSystem.LibraryManagement.Utlis;
using Microsoft.EntityFrameworkCore;

namespace LibraryManagementSystem.Repositories
{
    public class BorrowingRecordRepository:IBorrowingRecordRepository
    {
        private readonly AppDbContext _context;

        public BorrowingRecordRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<Result<List<TblBorrowingRecord>>> GetBorrowingRecordsAsync()
        {
            var borrowingRecords = await _context.TblBorrowingRecords.ToListAsync();
            return Result<List<TblBorrowingRecord>>.Success(borrowingRecords!);
        }
    }
}

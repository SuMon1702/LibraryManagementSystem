using LibraryManagementSystem.LibraryManagement.Utlis;
using LibraryManagementSystem.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace LibraryManagementSystem.Repositories.Implementations
{
    public class BorrowingRecordRepository : IBorrowingRecordRepository
    {
        private readonly AppDbContext _context;

        public BorrowingRecordRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<Result<List<TblBorrowingRecord>>> GetBorrowingRecordsAsync(CancellationToken cs)
        {
            var borrowingRecords = await _context.TblBorrowingRecords.ToListAsync(cs);
            if (borrowingRecords is null || borrowingRecords.Count == 0)
            {
                return Result<List<TblBorrowingRecord>>.Fail("No data found");
            }
            return Result<List<TblBorrowingRecord>>.Success(borrowingRecords!);
        }

        public async Task<Result<TblBorrowingRecord?>> GetBorrowingRecordByIdAsync(int id)
        {
            var borrowingRecord = await _context.TblBorrowingRecords.FirstOrDefaultAsync(x => x.BorrowingRecordId == id);
            if (borrowingRecord is null)
            {
                return Result<TblBorrowingRecord?>.Fail("No data found");
            }
            return Result<TblBorrowingRecord?>.Success(borrowingRecord);
        }
    }
}

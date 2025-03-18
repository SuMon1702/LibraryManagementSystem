namespace LibraryManagementSystem.Controllers;

[Route("api/[controller]")]
[ApiController]
public class BorrowingRecordController : ControllerBase
{
    private readonly IBorrowingRecordService service;

    public BorrowingRecordController(IBorrowingRecordService service)
    {
        this.service = service;
    }

    [HttpGet]
    public async Task<ActionResult<List<TblBorrowingRecord>>> GetBorrowingRecordsAsync(CancellationToken cs)
    {
        var result = await service.GetBorrowingRecordsAsync(cs);
        return Ok(result);
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<TblBorrowingRecord>> GetBorrowingRecordByIdAsync(int id)
    {
        var result = await service.GetBorrowingRecordsByIdAsync(id);
        return Ok(result);

        //    [HttpPost("BorrowBook")]
        //    public async Task<ActionResult<Result<TblBorrowingRecord>>> BorrowBook(BorrowModel model)
        //    {
        //        if (model == null)
        //        {
        //            return Result<TblBorrowingRecord>.Fail("No data is found");
        //        }

        //        var book = await _context.TblBooks.FindAsync(model.BookID);
        //        var member = await _context.TblMembers.FindAsync(model.MemberID);

        //        if (book == null || member == null)
        //            return NotFound("Book or Member not found.");

        //        if (book.Quantity <= 0)
        //            return BadRequest("Book is out of stock.");

        //        if (book.Quantity < model.Quantity)
        //            return BadRequest("Not enough books in stock.");

        //        if (member.ExpireDate <= DateTime.Now)
        //            return BadRequest("Membership has expired.");

        //        var borrowingRecord = new TblBorrowingRecord
        //        {
        //            BookId = model.BookID,
        //            MemberId = model.MemberID,
        //            Quantity = model.Quantity,
        //            BookPrice = book.BookAmount,
        //            TotalAmount = model.Quantity * book.BookAmount,
        //            BorrowDate = DateTime.Now,
        //            DueDate = DateTime.Now.AddDays(14),
        //            ReturnDate = null

        //        };

        //        //Updates the number of books available in stock by reducing it by the quantity the user is borrowing.
        //        book.Quantity -= model.Quantity;

        //        _context.TblBorrowingRecords.Add(borrowingRecord); // Add new record to database
        //        _context.TblBooks.Update(book); // Update the book's quantity in the database
        //        await _context.SaveChangesAsync();

        //        return Result<TblBorrowingRecord>.Success("Book borrowed successfully");

        //    }

        //    [HttpPut("ReturnBook/{id}")]
        //    public async Task<ActionResult<Result<TblBorrowingRecord>>> ReturnBook(int id)
        //    {
        //        var borrowingRecord = await _context.TblBorrowingRecords.FindAsync(id);

        //        if (borrowingRecord is null)
        //        {
        //            return Result<TblBorrowingRecord>.Fail("No record found.");
        //        }

        //        var book = await _context.TblBooks.FindAsync(borrowingRecord.BookId);
        //        if (book is null)
        //        {
        //            return Result<TblBorrowingRecord>.Fail("No book found.");
        //        }
        //        borrowingRecord.ReturnDate = DateTime.Now;


        //        // Check if the return date is after the due date and calculate excess days
        //        if (borrowingRecord.ReturnDate.HasValue && borrowingRecord.DueDate.HasValue && borrowingRecord.ReturnDate > borrowingRecord.DueDate)
        //        {
        //            TimeSpan timeSpan = borrowingRecord.ReturnDate.Value - borrowingRecord.DueDate.Value;  // Time span between return date and due date
        //            int exceedDays = timeSpan.Days;  // Get the number of exceeded days

        //            if (exceedDays > 0)
        //            {
        //                borrowingRecord.TotalAmount += exceedDays * 10; // Add fine for the exceeded days
        //            }
        //        }

        //            // Add returned books to the total quantity
        //            book.Quantity += borrowingRecord.Quantity;

        //            await _context.SaveChangesAsync();

        //            return Result<TblBorrowingRecord>.Success("Book returned successfully");

        //    }

        //    [HttpGet("GetBorrowingRecords")]
        //    public async Task<ActionResult<Result<List<TblBorrowingRecord>>>> GetBorrowingRecords()
        //    {
        //        var borrowingRecords = await _context.TblBorrowingRecords.ToListAsync();

        //        if (borrowingRecords.Count == 0)
        //        {
        //            return Result<List<TblBorrowingRecord>>.Fail("No records found.");
        //        }

        //        return Result<List<TblBorrowingRecord>>.Success(borrowingRecords);
        //    }
        //}
    }
}

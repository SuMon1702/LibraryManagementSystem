using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using LibraryManagementSystem.Models;
using LibraryManagementSystem.LibraryManagement.Utlis;
using LibraryManagementSystem.Model;
using LibraryManagementSystem.Services;

namespace LibraryManagementSystem.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookController : ControllerBase
    {
        private readonly IBookService service;

        public BookController(IBookService service)
        {
            this.service = service;
        }



        #region GetBooksAsync
        // GET: api/BookList
        [HttpGet]
        public async Task<ActionResult<Result<IEnumerable<TblBook>>>> GetBooksAsync(CancellationToken cs)
        {
            try
            {
                var result = await service.GetBooksAsync();
                return Ok(result);

                //var book = await _context
                //    .TblBooks
                //    .OrderByDescending(x => x.BookId)
                //    .Where(x => !x.IsActive)
                //    .ToListAsync(cs);

                ////This is not needed if returning [] is fine when no data is found.
                //if (book.Count == 0)
                //{
                //    return Result<IEnumerable<TblBook>>.Fail("No book is found.");
                //}
                //else
                //{
                //    return Result<IEnumerable<TblBook>>.Success(book);
                //}
            }

            catch (Exception ex)
            {
                return Result<IEnumerable<TblBook>>.Fail(ex);
            }
        }
        #endregion

        #region GetBookAsync
        // GET: api/Book/
        [HttpGet("{id}")]
        public async Task<ActionResult<Result<TblBook>>> GetBookAsync(int id)
        {
            try
            {
                var book = await service.FindAsync(id);
                return Ok(book);

                ////Since book is a single object (not a collection),don't need to use .Any().
                //if (book is null)
                //{
                //    return Result<TblBook>.Fail("No book is found.");
                //}

                //result = Result<TblBook>.Success(book);
                //return result;

            }
            catch (Exception ex)
            {
                return Result<TblBook>.Fail(ex);
            }
        }
        #endregion

        //#region CreateBook
        //[HttpPost]
        //public async Task<ActionResult<TblBook>> CreateBook([FromBody] BookRequestModel requestModel, CancellationToken cs)
        //{
        //    try
        //    {

        //        //If we use the scaffold model then we do not need to create this instance.
        //        //But if we use the one model that we built then we need this instance
        //        var model = new TblBook()
        //        {
        //            BookTitle = requestModel.BookTitle,
        //            Author = requestModel.Author,
        //            Quantity = requestModel.Quantity,
        //            BookAmount = requestModel.BookAmount,
        //            Publisher = requestModel.Publisher

        //        };

        //        await _context.TblBooks.AddAsync(model, cs);
        //        var result = await _context.SaveChangesAsync(cs);

        //        string message = result > 0 ? "Saving Successful" : "Saving Fail";
        //        return Ok(message);
        //    }
        //    catch (Exception ex)
        //    {
        //        return BadRequest(ex);
        //    }
        //}
        //#endregion


        //#region UpdateBook
        //[HttpPut("{id}")]
        //public async Task<ActionResult<Result<TblBook>>>UpdateBook(int id, BookModel model)
        //{
        //    try
        //    {
        //        var item = await _context.TblBooks.FirstOrDefaultAsync(x => x.BookId == id);

        //        if (item is null)
        //        {
        //            return Result<TblBook>.Fail("No data found");
        //        }

        //        if (model is null)
        //        {
        //            return Result<TblBook>.Fail("Please fill all field.");
        //        }

        //        item.Quantity = model.Quantity;
        //        item.BookAmount = model.BookAmount;


        //        _context.Entry(item).State = EntityState.Modified;
        //        await _context.SaveChangesAsync();

        //        return Result<TblBook>.Success(item,"Updating Succeed");
        //    }
        //    catch (Exception ex)
        //    {
        //        return Result<TblBook>.Fail(ex);
        //    }
        //}
        //#endregion

        //#region DeleteBook
        //[HttpDelete("{id}")]
        //public async Task<ActionResult<Result<TblBook>>> DeleteBook (int id)
        //{
        //    try
        //    {
        //        var item = await _context.TblBooks.FirstOrDefaultAsync(x => x.BookId == id);
        //        if (item is null)
        //        {
        //            return Result<TblBook>.Fail("No data found");
        //        }

        //        var isLinkedToTransactions = await _context.TblBorrowingRecords.AnyAsync(t => t.BookId == id && t.ReturnDate == null);
        //        if (isLinkedToTransactions)
        //            return BadRequest("Cannot delete the book as it is currently borrowed.");

        //        item.IsActive = false;
        //        _context.Entry(item).State = EntityState.Modified;
        //       await _context.SaveChangesAsync();

        //        return Result<TblBook>.Success(item,"Deleted successfully");
        //    }
        //    catch (Exception ex)
        //    {
        //        return Result<TblBook>.Fail(ex);
        //    }
        //}
        //#endregion
    }
}

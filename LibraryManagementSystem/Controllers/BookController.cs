using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using LibraryManagementSystem.Models;
using LibraryManagementSystem.LibraryManagement.Utlis;
using static System.Reflection.Metadata.BlobBuilder;
using LibraryManagementSystem.Model;
using Microsoft.AspNetCore.Http.HttpResults;

namespace LibraryManagementSystem.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookController : ControllerBase
    {
        private readonly AppDbContext _context;

        public BookController(AppDbContext context)
        {
            _context = context;
        }

        // GET: api/BookList
        [HttpGet]
        public async Task<ActionResult<Result<IEnumerable<Book>>>> GetBooksAsync(CancellationToken cs)
        {
            try
            {
                var book = await _context
                    .Books
                    .OrderByDescending(x => x.BookId)
                    .Where(x => !x.IsDelete)
                    .ToListAsync(cs);

                //This is not needed if returning [] is fine when no data is found.
                if (book.Count == 0)
                {
                    return Result<IEnumerable<Book>>.Fail("No book is found.");
                }
                else
                {
                    return Result<IEnumerable<Book>>.Success(book);
                }
            }

            catch (Exception ex)
            {
                return Result<IEnumerable<Book>>.Fail(ex);
            }
        }

        // GET: api/Book/
        [HttpGet("{id}")]
        public async Task<ActionResult<Result<Book>>> GetBookAsync(int id)
        {
            try
            {
                Result<Book> result;

                var book = await _context.Books.FindAsync(id);

                //Since book is a single object (not a collection),don't need to use .Any().
                if (book is null)
                {
                    return Result<Book>.Fail("No book is found.");
                }

                result = Result<Book>.Success(book);
                return result;

            }
            catch (Exception ex)
            {
                return Result<Book>.Fail(ex);
            }
        }

        [HttpPost]
        public async Task<ActionResult<Book>> CreateBook([FromBody] BookRequestModel requestModel, CancellationToken cs)
        {
            try
            {

                //If we use the scaffold model then we do not need to create this instance.
                //But if we use the one model that we built then we need this instance
                var model = new Book()
                {
                    BookTitle = requestModel.BookTitle,
                    Author = requestModel.Author,
                    BookQty = requestModel.BookQty,
                    BookPrice = requestModel.BookPrice,
                    Publisher = requestModel.Publisher

                };

                await _context.Books.AddAsync(model, cs);
                var result = await _context.SaveChangesAsync(cs);

                string message = result > 0 ? "Saving Successful" : "Saving Fail";
                return Ok(message);
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<Result<Book>>>UpdateBook(int id, BookRequestModel requestModel)
        {
            try
            {
                var item = await _context.Books.FirstOrDefaultAsync(x => x.BookId == id);

                if (item is null)
                {
                    return Result<Book>.Fail("No data found");
                }

                if (requestModel is null)
                {
                    return Result<Book>.Fail("Please fill all field.");
                }

                item.BookTitle = requestModel.BookTitle;
                item.Author = requestModel.Author;
                item.BookQty = requestModel.BookQty;
                item.BookPrice = requestModel.BookPrice;
                item.Publisher = requestModel.Publisher;

                _context.Entry(item).State = EntityState.Modified;
                await _context.SaveChangesAsync();

                return Result<Book>.Success(item,"Updating Succeed");
            }
            catch (Exception ex)
            {
                return Result<Book>.Fail(ex);
            }
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<Result<Book>>> DeleteBook (int id)
        {
            try
            {
                var item = await _context.Books.FirstOrDefaultAsync(x => x.BookId == id);
                if (item is null)
                {
                    return Result<Book>.Fail("No data found");
                }

                _context.Books.Remove(item);
                _context.Entry(item).State = EntityState.Modified;
                _context.SaveChanges();

                return Result<Book>.Success(item,"Deleted successfully");
            }
            catch (Exception ex)
            {
                return Result<Book>.Fail(ex);
            }
        }
    }
}

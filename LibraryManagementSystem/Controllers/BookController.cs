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

                result= Result<Book>.Success(book);
                return result;
                
            }
            catch (Exception ex)
            {
                return Result<Book>.Fail(ex); 
            }
        }

        [HttpPost]
        public async Task<ActionResult<Result<Book>>> CreateBook([FromBody] BookRequestModel requestModel,CancellationToken cs)
        {
            try
            {
                Result<Book> result;
                var model = new Book()
                {
                    BookTitle = requestModel.BookTitle,
                    Author= requestModel.Author,
                    BookQty= requestModel.BookQty,
                    BookPrice= requestModel.BookPrice,
                    Publisher= requestModel.Publisher

                };
                await _context.Books.AddAsync(model, cs);
                await _context.SaveChangesAsync(cs);

                result= Result<Book>.Success(model);
                return result;
            }
            catch (Exception ex)
            {
                return Result<Book>.Fail(ex);   
            }
        }
    }
}

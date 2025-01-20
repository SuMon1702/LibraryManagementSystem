using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using LibraryManagementSystem.Models;

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
        public async Task<ActionResult<IEnumerable<Book>>> GetBooksAsync (CancellationToken cs)
        {
            try
            {
                var book= await _context
                    .Books
                    .OrderByDescending(x => x.BookId)
                    .Where(x => !x.IsDelete)
                    .ToListAsync(cs);

                //This is not needed if returning [] is fine when no data is found.
                if (!book.Any())
                {
                    return NotFound("No book is found.");
                }

                return book;
                
            }
            
            catch (Exception ex)
            {
                return BadRequest($"An error occurs: {ex.Message}");
            }
        }

        
    }
}

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
    public class BorrowingRecordController : ControllerBase
    {
        private readonly AppDbContext _context;

        public BorrowingRecordController(AppDbContext context)
        {
            _context = context;
        }

        // GET: api/BorrowingRecordList
        [HttpGet]
        public async Task<ActionResult<IEnumerable<BorrowingRecord>>> GetBorrowingRecords()
        {
            return await _context.BorrowingRecords.ToListAsync();
        }

        
    }
}

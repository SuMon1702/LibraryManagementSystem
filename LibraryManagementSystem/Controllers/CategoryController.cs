﻿using LibraryManagementSystem.LibraryManagement.Utlis;
using LibraryManagementSystem.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace LibraryManagementSystem.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        private readonly AppDbContext _context;

        public CategoryController(AppDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<Result<List<TblCategory>>>> GetCategoriesAsync(CancellationToken cs)
        {
            var category = await _context.TblCategories.ToListAsync(cs);
            return Result<List<TblCategory>>.Success(category);
        }


    }
    
}

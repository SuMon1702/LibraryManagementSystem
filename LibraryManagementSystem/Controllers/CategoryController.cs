using LibraryManagementSystem.LibraryManagement.Utlis;
using LibraryManagementSystem.Model;
using LibraryManagementSystem.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Drawing.Design;

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

        [HttpGet("{id}")]
        public async Task<ActionResult<Result<TblCategory>>> GetCategoryAsync(int id)
        {
            var category = await _context.TblCategories.FindAsync(id);
            if (category == null)
            {
                return Result<TblCategory>.Fail("No data is found");
            }
            return Result<TblCategory>.Success(category);
        }

        [HttpPost]
        public async Task<ActionResult<Result<TblCategory>>> CreateCategory([FromBody] CategoryModel model, CancellationToken cs)
        {
            try
            {
                var category = new TblCategory()
                {
                    CategoryName = model.CategoryName
                };

                await _context.TblCategories.AddAsync(category,cs);

               if(string.IsNullOrEmpty(model.CategoryName))
                {
                    return Result<TblCategory>.Fail("Category name must be filled");
                }

                await _context.SaveChangesAsync(cs);

                return Result<TblCategory>.Success(category);
                
            }
            catch (Exception ex)
            {
                return Result<TblCategory>.Fail(ex.Message);
            }
        }
    }
    
}


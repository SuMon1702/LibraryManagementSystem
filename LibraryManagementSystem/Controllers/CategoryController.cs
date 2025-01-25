using LibraryManagementSystem.LibraryManagement.Utlis;
using LibraryManagementSystem.Model;
using LibraryManagementSystem.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace LibraryManagementSystem.Controllers;

[Route("api/[controller]")]
[ApiController]
public class CategoryController : ControllerBase
{
    private readonly AppDbContext _context;

    public CategoryController(AppDbContext context)
    {
        _context = context;
    }

    #region GetCategoriesAsync
    [HttpGet]
    public async Task<ActionResult<Result<List<TblCategory>>>> GetCategoriesAsync(CancellationToken cs)
    {
        var category = await _context.TblCategories.ToListAsync(cs);
        return Result<List<TblCategory>>.Success(category);
    }
    #endregion


    #region GetCategoryAsync
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
    #endregion


    #region CreateCategoryAsync
    [HttpPost]
    public async Task<ActionResult<Result<TblCategory>>> CreateCategoryAsync([FromBody] CategoryModel model, CancellationToken cs)
    {
        try
        {
       // This instance maps the valid request model data to the TblCategory entity
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
    #endregion

    [HttpDelete("{id}")]
    public async Task<ActionResult<Result<TblCategory>>> DeleteCategoryAsync(int id)
    {
        var category = await _context.TblCategories.FindAsync(id);

        if(category is null)
        {
            return Result<TblCategory>.Fail("Category is not found.");
        }

        // Check if any books are linked to this category
        var booksInCategory = await _context.TblBooks.AnyAsync(b => b.CategoryId == id);
        if (booksInCategory)
        {
            return BadRequest("Cannot delete the category because books are linked to it.");
        }

        // Soft delete the category
        category.IsActive = false;
        _context.TblCategories.Update(category);
        await _context.SaveChangesAsync();

        return Result<TblCategory>.Success("Deleted successfully");

    }
}

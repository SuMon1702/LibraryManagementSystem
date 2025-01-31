using LibraryManagementSystem.LibraryManagement.Utlis;
using LibraryManagementSystem.Model;
using LibraryManagementSystem.Models;
using LibraryManagementSystem.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace LibraryManagementSystem.Controllers;

[Route("api/[controller]")]
[ApiController]
public class AdminController : ControllerBase
{

    private readonly IAdminService _service;

    public AdminController(IAdminService service)
    {
        _service = service;
    }


    #region GetAdminsAsync
    [HttpGet]
    public async Task<ActionResult<Result<List<TblAdmin>>>> GetAdminsAsync()
    {

        var result = await _service.GetAdminsAsync();
        return result;
    }
    #endregion


    #region GetAdminAsync
    [HttpGet("{id}")]
    public async Task<ActionResult<Result<TblAdmin>>> GetAdminAsync(int id)
    {
        var result = await _service.GetAdminByIdAsync(id);
        return result;
    }
    #endregion


    #region AdminLogin
    [HttpPost("admin_Login")]
    public async Task<ActionResult<Result<TblAdmin>>> AdminLogin([FromBody] AdminLoginModel login)
    {
        var result = await _service.AdminLogin(login);
        return result;
    }
    #endregion


    //#region 
    //[HttpPut("{id}")]
    //public async Task<ActionResult<Result<TblAdmin>>> UpdateAdmin(int id, AdminModel model)
    //{
    //    var item = await _context.TblAdmins.FirstOrDefaultAsync(x => x.AdminId == id);
    //    if (item is null)
    //    {
    //        return Result<TblAdmin>.Fail("No item is found");
    //    }

    //    item.Address = model.Address;
    //    item.AdminName = model.AdminName;

    //    _context.Entry(item).State = EntityState.Modified;
    //    await _context.SaveChangesAsync();

    //    return Result<TblAdmin>.Success(item, "Updating succeed");
    //}
    //#endregion

}


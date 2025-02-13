using LibraryManagementSystem.LibraryManagement.Utlis;
using LibraryManagementSystem.Model;
using LibraryManagementSystem.Models;
using LibraryManagementSystem.Services;
using Microsoft.AspNetCore.Mvc;
using System.Web.Http;
using FromBodyAttribute = Microsoft.AspNetCore.Mvc.FromBodyAttribute;
using HttpGetAttribute = Microsoft.AspNetCore.Mvc.HttpGetAttribute;
using HttpPostAttribute = Microsoft.AspNetCore.Mvc.HttpPostAttribute;
using HttpPutAttribute = Microsoft.AspNetCore.Mvc.HttpPutAttribute;
using RouteAttribute = Microsoft.AspNetCore.Mvc.RouteAttribute;
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


    #region 
    [HttpPut("{id}")]
    public async Task<ActionResult<Result<TblAdmin>>> UpdateAdmin(int id, AdminModel model)
    {
        if (model is null)
        {
            return BadRequest("Invalid request");
        }
       var item = await _service.UpdateAdmin(id, model);
       return item;
    }
    #endregion

}


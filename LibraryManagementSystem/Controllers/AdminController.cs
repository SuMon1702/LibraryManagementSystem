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


  
}


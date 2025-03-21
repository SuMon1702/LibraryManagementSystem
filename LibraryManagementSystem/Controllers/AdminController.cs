﻿using LibraryManagementSystem.Dtos;
using LibraryManagementSystem.Model;

namespace LibraryManagementSystem.Controllers
{
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
        public async Task<ActionResult<List<TblAdmin>>> GetAdminsAsync(CancellationToken cs)
        {

            var result = await _service.GetAdminsAsync(cs);
            return Ok(result);
        }
        #endregion

        #region GetAdminAsync
        [HttpGet("{id}")]
        public async Task<ActionResult<TblAdmin>> GetAdminByIdAsync(int id)
        {
            var result = await _service.GetAdminByIdAsync(id);
            return Ok(result);
        }
        #endregion


        #region AdminLogin
        [HttpPost("admin_Login")]
        public async Task<ActionResult<TblAdmin>> AdminLogin([FromBody] AdminLoginModel login)
        {
            // Automatically validates the model based on the annotations in AdminLoginModel
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);  // Return validation errors if the model is invalid
            }

            var result = await _service.AdminLogin(login);
            return Ok(result);
        }
        #endregion


        #region UpdateAdmin
        [HttpPut("{id}")]
        public async Task<ActionResult<TblAdmin>> UpdateAdmin(int id, AdminModel model)
        {
            if (model is null)
            {
                return BadRequest("Invalid request");
            }
            var item = await _service.UpdateAdmin(id, model);
            return Ok(item);
        }
        #endregion

        #region ResetPassword
        [HttpPut("resetPassword/{adminId}")]
        public async Task<ActionResult<TblAdmin>> ResetPassword(int adminId, [FromBody] AdminResetModel reset)
        {
            if (reset is null || string.IsNullOrWhiteSpace(reset.Password))
            {
                return BadRequest("Invalid request. Password cannot be empty.");
            }

            var item = await _service.ResetPassword(adminId, reset.Password);

            if (!item.IsSuccess)
            {
                return BadRequest(item.Message); 
            }

            return Ok(item);
        }
        #endregion

    }
}

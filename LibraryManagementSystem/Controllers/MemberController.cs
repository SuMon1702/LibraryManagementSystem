using LibraryManagementSystem.LibraryManagement.Utlis;
using LibraryManagementSystem.Model;
using LibraryManagementSystem.Models;
using LibraryManagementSystem.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using System.Diagnostics.Metrics;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace LibraryManagementSystem.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MemberController : ControllerBase
    {
        private readonly IMemberService service;

        public MemberController(IMemberService service)
        {
            this.service = service;
        }

        [HttpGet]
        public async Task<ActionResult<List<TblMember>>> GetMembersAsync(CancellationToken cs)
        {
            var result = await service.GetMembersAsync();
            return Ok(result);
        }

        //[HttpGet("{id}")]
        //public async Task<ActionResult<Result<TblMember>>> GetMemberAsync(int id)
        //{
        //    var member = await _context.TblCategories.FindAsync(id);
        //    if (member is null)
        //    {
        //        return Result<TblMember>.Fail("No member is found");
        //    }
        //    return Result<TblMember>.Success("Succeed");
        //}

        //[HttpPost("Member_Register")]
        //public async Task<ActionResult<Result<TblMember>>> MemberRegister(MemberRegisterModel regModel)
        //{

        //    if (regModel is null)
        //    {
        //        return Result<TblMember>.Fail("Invalid Member data.");
        //    }

        //    var existingMember = await _context.TblMembers.FirstOrDefaultAsync(m => m.Email == regModel.Email);
        //    if (existingMember != null)
        //        return BadRequest("A member with this email already exists.");

        //    //All the data annotations should be filled since they are written [Required], 
        //    if (!ModelState.IsValid)
        //    {
        //        return BadRequest("Please fill all fields");
        //    }

        //    if (!Enum.IsDefined(typeof(MemberShipType), regModel.MembershipType))
        //        return BadRequest("Invalid MembershipType. Allowed values are 'Premium' and 'Standard'.");
            


        //    var model = new TblMember()
        //    {
        //        MemberName = regModel.MemberName,
        //        Email = regModel.Email,
        //        Password = regModel.Password,
        //        Address = regModel.Address,
        //        PhoneNumber = regModel.PhoneNumber,
        //        MembershipType = regModel.MembershipType.ToString(),
        //        MembershipDate = DateTime.Now, //Set the MembershipDate to the current date and time
        //        ExpireDate = DateTime.Now.AddMonths(6) // Default 6 month membership validation
        //    };

        //    await _context.TblMembers.AddAsync(model);
        //    await _context.SaveChangesAsync();

        //    return Result<TblMember>.Success(model,"Member registered successfully.");
        //}

        //[HttpPost("Member_Login")]
        //public async Task<ActionResult<Result<TblMember>>> MemberLogin(MemberLoginModel loginModel)
        //{
        //    try
        //    {
        //        if (loginModel is null)
        //        {
        //            return Result<TblMember>.Fail("Invalid Login");
        //        }

        //        var member = await _context.TblMembers.FirstOrDefaultAsync(l => l.Email == loginModel.Email && l.Password == loginModel.Password);

        //        if (member == null)
        //        {
        //            return Result<TblMember>.Fail("Invalid email and password");
        //        }

        //        return Result<TblMember>.Success(member, "Login is succeed");
        //    }
        //    catch (Exception)
        //    {
        //        return Result<TblMember>.Fail("An error occurred during member login");
        //    }
        //}

        //[HttpPut("{id}")]
        //public async Task<ActionResult<Result<TblMember>>> UpdateMember(int id, MemberUpdateModel model)
        //{
        //    var member = await _context.TblMembers.FirstOrDefaultAsync(x => x.MemberId == id);

        //    if (member is null)
        //    {
        //        return Result<TblMember>.Fail("No member is found");
        //    }

        //    member.MemberName = model.MemberName;
        //    member.PhoneNumber = model.PhoneNumber;
        //    member.Email = model.Email;
        //    member.Address = model.Address;
        //    member.MembershipType = model.MembershipType.ToString();
        //    member.Password = model.Password;

        //    _context.Entry(member).State = EntityState.Modified;
        //    await _context.SaveChangesAsync();

        //    return Result<TblMember>.Success(member, "Updating succeed");
        //}

        //[HttpDelete("{id}")]
        //public async Task<ActionResult<Result<TblMember>>> DeleteMember(int id)
        //{
        //    var member = await _context.TblMembers.FirstOrDefaultAsync(x => x.MemberId == id);

        //    if (member is null)
        //    {
        //        return Result<TblMember>.Fail("No member is found");
        //    }

        //    member.IsActive = false;
        //    _context.Entry(member).State = EntityState.Modified;
        //    await _context.SaveChangesAsync();

        //    return Result<TblMember>.Success("Deleted successfully");
        //}
    }
}

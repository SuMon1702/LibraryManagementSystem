using LibraryManagementSystem.LibraryManagement.Utlis;
using LibraryManagementSystem.Model;
using LibraryManagementSystem.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace LibraryManagementSystem.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MemberController : ControllerBase
    {
        private readonly AppDbContext _context;

        public MemberController(AppDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<Result<List<TblMember>>>> GetMembersAsync(CancellationToken cs)
        {
            var member = await _context.TblMembers.ToListAsync(cs);
            return Result<List<TblMember>>.Success(member);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Result<TblMember>>> GetMemberAsync(int id)
        {
            var member = await _context.TblCategories.FindAsync(id);
            if (member is null)
            {
                return Result<TblMember>.Fail("No member is found");
            }
            return Result<TblMember>.Success("Succeed");
        }

        [HttpPost("Member_Register")]
        public async Task<ActionResult<Result<TblMember>>> MemberRegister(MemberRegisterModel regModel)
        {

            if (regModel is null)
            {
                return Result<TblMember>.Fail("Invalid Member data.");
            }

            //All the data annotations should be filled since they are written [Required], 
            if (!ModelState.IsValid)
            {
                return BadRequest("Please fill all fields");
            }

            if (!Enum.IsDefined(typeof(MemberShipType), regModel.MembershipType))
                return BadRequest("Invalid MembershipType. Allowed values are 'Premium' and 'Standard'.");

            var model = new TblMember()
            {
                MemberName = regModel.MemberName,
                Email = regModel.Email,
                Password = regModel.Password,
                Address = regModel.Address,
                PhoneNumber = regModel.PhoneNumber,
                MembershipType = regModel.MembershipType.ToString(),
                MembershipDate = DateTime.Now, //Set the MembershipDate to the current date and time
                ExpireDate = DateTime.Now.AddMonths(6)
            };



            await _context.TblMembers.AddAsync(model);
            await _context.SaveChangesAsync();

            return Result<TblMember>.Success(model);
        }

        [HttpPost("Member_Login")]
        public async Task<ActionResult<Result<TblMember>>> MemberLogin(MemberLoginModel loginModel)
        {
            try
            {
                if (loginModel is null)
                {
                    return Result<TblMember>.Fail("Invalid Login");
                }

                var member = await _context.TblMembers.FirstOrDefaultAsync(l => l.Email == loginModel.Email && l.Password == loginModel.Password);

                if (member == null)
                {
                    return Result<TblMember>.Fail("Invalid email and password");
                }

                return Result<TblMember>.Success(member, "Login is succeed");
            }
            catch (Exception)
            {
                return Result<TblMember>.Fail("An error occurred during member login");
            }
        }
    }
}

using System.ComponentModel.DataAnnotations;

namespace LibraryManagementSystem.Model
{
    public class MemberRegisterModel
    {
        [Required]
        public string MemberName { get; set; } = null!;

        [Required]
        public string PhoneNumber { get; set; } = null!;

        [Required]
        public string Email { get; set; } = null!;

        [Required]
        public string? Password { get; set; }
        [Required]
        public string Address { get; set; } = null!;

        [Required]
        public MemberShipType MembershipType { get; set; } 
    }
}

using System.ComponentModel.DataAnnotations;

namespace LibraryManagementSystem.Model
{
    public class MemberLoginModel
    {
        [Required]
        public string Email { get; set; } = null!;

        [Required]
        public string? Password { get; set; }
    }
}

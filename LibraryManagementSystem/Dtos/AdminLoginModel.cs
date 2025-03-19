using System.ComponentModel.DataAnnotations;

namespace LibraryManagementSystem.Model
{
    public class AdminLoginModel
    {
        
        [Required]  //Add Data Annotations
        [EmailAddress] //Add Data Annotations
        public string Email { get; set; } = null!;

        [Required]
        [MinLength(8)]
        public string Password { get; set; } = null!;
    }
}

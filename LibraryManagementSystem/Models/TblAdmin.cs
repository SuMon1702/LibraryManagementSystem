namespace LibraryManagementSystem.Models;

public partial class TblAdmin
{
    public int AdminId { get; set; }

    public string AdminName { get; set; } = null!;

    public string Address { get; set; } = null!;

    public string Email { get; set; } = null!;

    public string Password { get; set; } = null!;

    public bool IsActive { get; set; }
}

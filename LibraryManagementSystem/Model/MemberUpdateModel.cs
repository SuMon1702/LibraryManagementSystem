namespace LibraryManagementSystem.Model
{
    public class MemberUpdateModel
    {
        public string MemberName { get; set; } = null!;

        public string PhoneNumber { get; set; } = null!;

        public string Email { get; set; } = null!;

        public string Address { get; set; } = null!;
        public MemberShipType MembershipType { get; set; } 
        public string? Password { get; set; }
    }
}

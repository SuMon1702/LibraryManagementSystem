using System;
using System.Collections.Generic;

namespace LibraryManagementSystem.Models;

public partial class TblMember
{
    public int MemberId { get; set; }

    public string MemberName { get; set; } = null!;

    public string PhoneNumber { get; set; } = null!;

    public string Email { get; set; } = null!;

    public string Address { get; set; } = null!;

    public DateOnly MembershipDate { get; set; }

    public string MembershipType { get; set; } = null!;

    public DateOnly ExpireDate { get; set; }

    public bool IsActive { get; set; }

    public byte[] RowVersion { get; set; } = null!;
}

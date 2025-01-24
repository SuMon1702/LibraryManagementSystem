using System;
using System.Collections.Generic;

namespace LibraryManagementSystem.Models;

public partial class TblBorrowingRecord
{
    public int BorrowingRecordId { get; set; }

    public int MemberId { get; set; }

    public int BookId { get; set; }

    public DateTime BorrowDate { get; set; }

    public DateTime? ReturnDate { get; set; }

    public DateTime DueDate { get; set; }

    public int Quantity { get; set; }

    public decimal BookPrice { get; set; }

    public decimal TotalAmount { get; set; }

    public int ExceedDay { get; set; }

    public byte[] RowVersion { get; set; } = null!;
}

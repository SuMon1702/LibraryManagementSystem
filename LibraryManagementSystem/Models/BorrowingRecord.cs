using System;
using System.Collections.Generic;

namespace LibraryManagementSystem.Models;

public partial class BorrowingRecord
{
    public int BorrowingRecordId { get; set; }

    public int MemberId { get; set; }

    public int BookId { get; set; }

    public DateOnly BorrowDate { get; set; }

    public DateOnly ReturnDate { get; set; }

    public DateOnly DueDate { get; set; }

    public int Quantity { get; set; }

    public decimal BookPrice { get; set; }

    public decimal TotalAmount { get; set; }

    public int ExceedDay { get; set; }
}

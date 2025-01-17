using System;
using System.Collections.Generic;

namespace LibraryManagementSystem.Models;

public partial class Book
{
    public int BookId { get; set; }

    public string BookTitle { get; set; } = null!;

    public string Author { get; set; } = null!;

    public int BookQty { get; set; }

    public string Publisher { get; set; } = null!;

    public decimal BookPrice { get; set; }

    public int CategoryId { get; set; }

    public bool IsDelete { get; set; }
}

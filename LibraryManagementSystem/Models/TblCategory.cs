﻿using System;
using System.Collections.Generic;

namespace LibraryManagementSystem.Models;

public partial class TblCategory
{
    public int CategoryId { get; set; }

    public string CategoryName { get; set; } = null!;

    public byte[] RowVersion { get; set; } = null!;
}
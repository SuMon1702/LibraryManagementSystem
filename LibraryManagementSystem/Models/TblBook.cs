namespace LibraryManagementSystem.Models
{
    public  class TblBook
    {
        public int BookId { get; set; } 

        public string BookTitle { get; set; } = null!;

        public string Author { get; set; } = null!;

        public int Quantity { get; set; }

        public string Publisher { get; set; } = null!;

        public decimal BookAmount { get; set; }

        public string Status { get; set; } = null!;

        public bool IsActive { get; set; }

        public int CategoryId { get; set; }

        public byte[] RowVersion { get; set; } = null!;
    }
}

namespace LibraryManagementSystem.Model
{
    public class BookRequestModel
    {
        public string BookTitle { get; set; } = null!;

        public string Author { get; set; } = null!;

        public int Quantity { get; set; }

        public string Publisher { get; set; } = null!;

        public decimal BookAmount { get; set; }
    }
}

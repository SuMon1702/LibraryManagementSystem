namespace LibraryManagementSystem.Model
{
    public partial class BookRequestModel
    {
        public string BookTitle { get; set; } = null!;

        public string Author { get; set; } = null!;

        public int BookQty { get; set; }

        public string Publisher { get; set; } = null!;

        public decimal BookPrice { get; set; }
    }
}

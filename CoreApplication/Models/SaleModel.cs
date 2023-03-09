namespace CoreApplication.Models
{
    public class SaleModel
    {
        public int Id { get; set; }
        public int Product { get; set; }
        public int Amount { get; set; }
        public DateTime SoldAt { get; set; }
        public int AddedBy { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime ModifiedAt { get; set; }
        public SaleModel()
        {
            SoldAt = DateTime.MinValue;
            CreatedAt = DateTime.MinValue;
            ModifiedAt = DateTime.MinValue;
        }
    }
}
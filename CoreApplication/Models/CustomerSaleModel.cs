namespace CoreApplication.Models
{
    public class CustomerSaleModel
    {
        public int Id { get; set; }
        public int Customer { get; set; }
        public int Sales { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime ModifiedAt { get; set; }
        public CustomerSaleModel()
        {
            CreatedAt = DateTime.MinValue;
            ModifiedAt = DateTime.MinValue;
        }
    }
}
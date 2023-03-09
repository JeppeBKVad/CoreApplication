namespace CoreApplication.Models
{
    public class CustomerModel
    {
        public int Id { get; set; }
        public string ExternalId { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime ModifiedAt { get; set; }
        public CustomerModel()
        {
            ExternalId = string.Empty;
            CreatedAt = DateTime.MinValue;
            ModifiedAt = DateTime.MinValue;
        }
    }
}
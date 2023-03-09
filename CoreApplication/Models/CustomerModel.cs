namespace CoreApplication.Models
{
    [TableName("customers")]
    public class CustomerModel : AbstractModel<CustomerModel>
    {
        [TableColumn("id")]
        public int Id { get; set; }

        [TableColumn("external_id")]
        public string ExternalId { get; set; }

        [TableColumn("created_at")]
        public DateTime CreatedAt { get; set; }

        [TableColumn("modified_at")]
        public DateTime ModifiedAt { get; set; }

        public CustomerModel()
        {
            ExternalId = string.Empty;
            CreatedAt = DateTime.MinValue;
            ModifiedAt = DateTime.MinValue;
        }
    }
}
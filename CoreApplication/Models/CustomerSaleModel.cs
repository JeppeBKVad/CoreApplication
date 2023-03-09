namespace CoreApplication.Models
{
    [TableName("customer_sale")]
    public class CustomerSaleModel : AbstractModel<CustomerSaleModel>
    {
        [TableColumn("id")]
        public int Id { get; set; }

        [TableColumn("customer")]
        public int Customer { get; set; }

        [TableColumn("sale")]
        public int Sale { get; set; }

        [TableColumn("created_at")]
        public DateTime CreatedAt { get; set; }

        [TableColumn("modified_at")]
        public DateTime ModifiedAt { get; set; }

        public CustomerSaleModel()
        {
            CreatedAt = DateTime.MinValue;
            ModifiedAt = DateTime.MinValue;
        }
    }
}
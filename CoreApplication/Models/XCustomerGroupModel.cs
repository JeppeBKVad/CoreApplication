namespace CoreApplication.Models
{
    [TableName("x_customer_group")]
    public class XCustomerGroupModel : AbstractModel<XCustomerGroupModel>
    {
        [TableColumn("id")]
        public int Id { get; set; }

        [TableColumn("customer")]
        public int Customer { get; set; }

        [TableColumn("group")]
        public int Group { get; set; }
    }
}

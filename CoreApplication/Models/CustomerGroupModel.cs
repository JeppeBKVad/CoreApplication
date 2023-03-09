using CoreApplication.Enums;

namespace CoreApplication.Models
{
    [TableName("customer_group")]
    public class CustomerGroupModel : AbstractModel<CustomerGroupModel>
    {
        [TableColumn("id")]
        public int Id { get; set; }

        [TableColumn("description")]
        public string Description { get; set; }

        [TableColumn("owned_by")]
        public int OwnedBy { get; set; }

        [TableColumn("created_at")]
        public DateTime CreatedAt { get; set; }

        [TableColumn("modified_at")]
        public DateTime ModifiedAt { get; set; }

        [TableColumn("status")]
        public ActiveStatus Status { get; set; }

        public CustomerGroupModel() {
            Description = string.Empty;
            CreatedAt = DateTime.MinValue;
            ModifiedAt = DateTime.MinValue;
            Status = ActiveStatus.Unknown;
        }
    }
}

using CoreApplication.Enums;

namespace CoreApplication.Models
{
    public class CustomerGroupModel
    {
        public int Id { get; set; }
        public string Description { get; set; }
        public int OwnedBy { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime ModifiedAt { get; set; }
        public ActiveStatus Status { get; set; }

        public CustomerGroupModel() {
            Description = string.Empty;
            CreatedAt = DateTime.MinValue;
            ModifiedAt = DateTime.MinValue;
            Status = ActiveStatus.Unknown;
        }
    }
}

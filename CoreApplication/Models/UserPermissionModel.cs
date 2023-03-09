using CoreApplication.Enums;

namespace CoreApplication.Models
{
    public class UserPermissionModel
    {
        public int Id { get; set; }
        public int User { get; set; }
        public PermissionLevel Permissions { get; set; }
        public int LastEditedBy { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime ModifiedAt { get; set; }

        public UserPermissionModel()
        {
            Permissions = PermissionLevel.Unknown;
            CreatedAt = DateTime.MinValue;
            ModifiedAt = DateTime.MinValue;
        }
    }
}
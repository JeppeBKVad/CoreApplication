using CoreApplication.Enums;

namespace CoreApplication.Models
{
    public class UserModel
    {
        public int Id { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }
        public ActiveStatus Status { get; set; }
        public int CreatedBy { get; set; }
        public int LastEditedBy { get; set; }
        public DateTime CreatedAt { get; set; } 
        public DateTime ModifiedAt { get; set; }

        public UserModel()
        {
            UserName = string.Empty;
            Password = string.Empty;
            Email = string.Empty;
            Status = ActiveStatus.Unknown;
            CreatedAt = DateTime.MinValue;
            ModifiedAt = DateTime.MinValue;
        }
    }
}

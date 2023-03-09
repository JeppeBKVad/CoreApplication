using CoreApplication.Enums;
using MySqlConnector;
using System.Text;

namespace CoreApplication.Models
{
    [TableName("users")]
    public class UserModel : AbstractModel<UserModel>
    {
        public static UserModel? findByUsername(string username)
        {
            return find(Tuple.Create("username", "=", username as object)).FirstOrDefault();
        }

        public static UserModel? findByEmail(string email)
        {
            return find(Tuple.Create("email", "=", email as object)).FirstOrDefault();
        }

        [TableColumn("id")]
        public int Id { get; set; }

        [TableColumn("username")]
        public string UserName { get; set; }

        [TableColumn("password")]
        public string Password { get; set; }

        [TableColumn("email")]
        public string Email { get; set; }

        [TableColumn("status")]
        public ActiveStatus Status { get; set; }

        [TableColumn("created_by")]
        public int CreatedBy { get; set; }

        [TableColumn("last_edited_by")]
        public int LastEditedBy { get; set; }

        [TableColumn("created_at")]
        public DateTime CreatedAt { get; set; }

        [TableColumn("modified_at")]
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

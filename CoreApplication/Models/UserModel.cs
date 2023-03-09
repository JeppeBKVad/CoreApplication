using CoreApplication.Enums;
using MySqlConnector;
using System.Data;

namespace CoreApplication.Models
{
    public class UserModel
    {
        public static UserModel fromMysqlReader(MySqlDataReader reader)
        {
            reader.Read();
            return new UserModel()
            {
                Id = reader.GetInt32("id"),
                UserName = reader.GetString("username"),
                Password = reader.GetString("password"),
                Email = reader.GetString("email"),
                Status = Enum.Parse<ActiveStatus>(reader.GetString("status"), true),
                CreatedBy = reader.GetInt32("created_by"),
                LastEditedBy = reader.GetInt32("last_edited_by"),
                CreatedAt = reader.GetDateTime("created_at"),
                ModifiedAt = reader.GetDateTime("modified_at"),
            };
        }

        public static UserModel? findUser(int id)
        {
            using var command = new MySqlCommand()
            {
                Connection = Database.Instance.connection,
                CommandText = "SELECT * FROM users WHERE id=@id",
            };
            command.Parameters.AddWithValue("id", id);

            using var reader = command.ExecuteReader();

            if (!reader.HasRows)
                return null;

            return fromMysqlReader(reader);
        }

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

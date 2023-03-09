namespace CoreApplication.Models
{
    public class User_permissions
    {
        public int Id { get; set; }
        public int User { get; set; }
        public string Permissions { get; set; } // Edit to enum
        public int Last_edited_by { get; set; }
        public DateTime Created_at { get; set; }
        public DateTime Modified_at { get; set; }
        public User_permissions(int id, int user, string permissions, int last_edited_by, DateTime created_at, DateTime modified_at)
        {
            this.Id = id;
            this.User = user;
            this.Permissions = permissions;
            this.Last_edited_by = last_edited_by;
            this.Created_at = created_at;
            this.Modified_at = modified_at;
        }
    }
}
namespace CoreApplication.Models
{
    [TableName("api_users")]
    public class ApiUserModel : AbstractModel<ApiUserModel>
    {
        public static ApiUserModel? findById(int id)
        {
            return find(Tuple.Create("id", "=", id as object)).FirstOrDefault();
        }

        public static ApiUserModel? findByToken(string token)
        {
            return find(Tuple.Create("current_token", "=", token as object)).FirstOrDefault();
        }

        public static IReadOnlyList<ApiUserModel> findByOwner(int ownerId)
        {
            return find(Tuple.Create("owner", "=", ownerId as object));
        }

        [TableColumn("id")]
        public int Id { get; set; }

        [TableColumn("current_token")]
        public string CurrentToken { get; set; }

        [TableColumn("owner")]
        public int OwnedBy { get; set; }

        [TableColumn("token_nonce")]
        public string TokenNonce { get; set; }

        [TableColumn("refreshable")]
        public bool Refreshable { get; set; }

        [TableColumn("expires_at")]
        public DateTime ExpiresAt { get; set; }

        [TableColumn("created_at")]
        public DateTime CreatedAt { get; set; }

        [TableColumn("last_used_at")]
        public DateTime LastUsedAt { get; set; }

        public ApiUserModel() {
            CurrentToken = string.Empty;
            TokenNonce = string.Empty;
            ExpiresAt = DateTime.MinValue;
            CreatedAt = DateTime.MinValue;
            LastUsedAt = DateTime.MinValue;
        }
        public static bool Verify(string currentToken, DateTime currentTime)
        {
            return true;
        }
    }
}

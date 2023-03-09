namespace CoreApplication.Models
{
    public class ApiUserModel
    {
        public int Id { get; set; }
        public string CurrentToken { get; set; }
        public int OwnedBy { get; set; }
        public string TokenNonce { get; set; }
        public bool Refreshable { get; set; }
        public DateTime ExpiresAt { get; set; }
        public DateTime CreatedAt { get; set; }
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

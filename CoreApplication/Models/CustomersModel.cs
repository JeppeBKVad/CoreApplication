namespace CoreApplication.Models
{
    public class Customers
    {
        public int Id { get; set; }
        public int External_id { get; set; }
        public DateTime Created_at { get; set; }
        public DateTime Modified_at { get; set; }
        public Customers(int id, int external_id, DateTime created_at, DateTime modified_at)
        {
            this.Id = id;
            this.External_id = external_id;
            this.Created_at = created_at;
            this.Modified_at = modified_at;
        }
    }
}
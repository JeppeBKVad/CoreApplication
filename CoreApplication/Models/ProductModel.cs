using MySqlConnector;

namespace CoreApplication.Models
{
    public class ProductModel
    {
        public static ProductModel fromMysqlReader(MySqlDataReader reader)
        {
            return new ProductModel()
            {
                Id = reader.GetInt32("id"),
                ExternalId = reader.GetString("external_id"),
                Name = reader.GetString("name"),
                Price = reader.GetFloat("price"),
                Description = reader.GetString("description"),
                AddedBy = reader.GetInt32("added_by"),
                CreatedAt = reader.GetDateTime("created_at"),
                ModifiedAt = reader.GetDateTime("modified_at"),
            };
        }
        public static IReadOnlyList<ProductModel> getTotal()
        {
            using var command = new MySqlCommand()
            {
                Connection = Database.Instance.connection,
                CommandText = "SELECT * FROM products;"
            };

            using var reader = command.ExecuteReader();
            var result = new List<ProductModel>();
            if (!reader.HasRows) 
                return result.AsReadOnly();

            while(reader.Read())
            {
                result.Add(fromMysqlReader(reader));
            }    
            return result.AsReadOnly();
        }
        public int Id { get; set; }
        public string ExternalId { get; set; }
        public string Name { get; set; }
        public float Price { get; set; }
        public string Description { get; set; }
        public int AddedBy { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime ModifiedAt { get; set; }
        public ProductModel()
        {
            ExternalId = string.Empty;
            Name = string.Empty;
            Description = string.Empty;
            CreatedAt = DateTime.MinValue;
            ModifiedAt = DateTime.MinValue;
        }
    }
}
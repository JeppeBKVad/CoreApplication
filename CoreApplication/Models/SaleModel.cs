using CoreApplication.Enums;
using MySqlConnector;

namespace CoreApplication.Models
{
    public class SaleModel
    {
        public static SaleModel fromMysqlReader(MySqlDataReader reader)
        {
            return new SaleModel()
            {
                Id = reader.GetInt32("id"),
                Product = reader.GetInt32("product"),
                Amount = reader.GetInt32("amount"),
                SoldAt = reader.GetDateTime("sold_at"),
                AddedBy = reader.GetInt32("added_by"),
                CreatedAt = reader.GetDateTime("created_at"),
                ModifiedAt = reader.GetDateTime("modified_at"),
            };
        }
        public static IReadOnlyList<SaleModel> getTotal()
        {
            using var command = new MySqlCommand()
            {
                Connection = Database.Instance.connection,
                CommandText = "SELECT * FROM sales;"
            };

            using var reader = command.ExecuteReader();
            var result = new List<SaleModel>();
            if (!reader.HasRows) 
                return result.AsReadOnly();

            while(reader.Read())
            {
                result.Add(fromMysqlReader(reader));
            }    
            return result.AsReadOnly();
        }
        public static IReadOnlyList<SaleModel> findSales(string productName)
        {
            using var command = new MySqlCommand()
            {
                Connection = Database.Instance.connection,
                CommandText = "SELECT * FROM sales AS s WHERE s.id IN(SELECT p.id FROM products AS p WHERE p.name LIKE @name)",
            };
            command.Parameters.AddWithValue("name", productName);

            using var reader = command.ExecuteReader();
            var result = new List<SaleModel>();
            if (!reader.HasRows) 
                return result.AsReadOnly();

            while(reader.Read())
            {
                result.Add(fromMysqlReader(reader));
            }    
            return result.AsReadOnly();
        }
        public static bool InsertSale(int id, int product, int amount, DateTime sold_at, int added_by)
        {
            using var command = new MySqlCommand()
            {
                Connection = Database.Instance.connection,
                CommandText = "INSERT INTO sales(id, product, amount, sold_at, added_by) VALUES " +
                    "(@id, @product, @amount, @sold_at, @added_by)"
            };
            command.Parameters.AddWithValue("id", id);
            command.Parameters.AddWithValue("product", product);
            command.Parameters.AddWithValue("amount", amount);
            command.Parameters.AddWithValue("sold_at", sold_at);
            command.Parameters.AddWithValue("added_by", added_by);

            command.ExecuteNonQuery();

            
            return true;
        }
        public int Id { get; set; }
        public int Product { get; set; }
        public int Amount { get; set; }
        public DateTime SoldAt { get; set; } 
        public int AddedBy { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime ModifiedAt { get; set; }
        public SaleModel()
        {
            SoldAt = DateTime.MinValue;
            CreatedAt = DateTime.MinValue;
            ModifiedAt = DateTime.MinValue;
        }
    }
}
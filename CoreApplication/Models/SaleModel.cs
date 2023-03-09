using CoreApplication.Enums;
using MySqlConnector;

namespace CoreApplication.Models
{
    [TableName("sales")]
    public class SaleModel : AbstractModel<SaleModel>
    {
        public static IReadOnlyList<SaleModel> findAll()
        {
            return find(Tuple.Create("1", "=", "1" as object));
        }

        public static IReadOnlyList<SaleModel> searchByName(string productName)
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
                result.Add(fromReader(reader));
            }    
            return result.AsReadOnly();
        }

        public static bool Insert(int id, int product, int amount, DateTime sold_at, int added_by)
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

        [TableColumn("id")]
        public int Id { get; set; }

        [TableColumn("product")]
        public int Product { get; set; }

        [TableColumn("amount")]
        public int Amount { get; set; }

        [TableColumn("sold_at")]
        public DateTime SoldAt { get; set; }

        [TableColumn("added_by")]
        public int AddedBy { get; set; }

        [TableColumn("created_at")]
        public DateTime CreatedAt { get; set; }

        [TableColumn("modified_at")]
        public DateTime ModifiedAt { get; set; }

        public SaleModel()
        {
            SoldAt = DateTime.MinValue;
            CreatedAt = DateTime.MinValue;
            ModifiedAt = DateTime.MinValue;
        }
    }
}
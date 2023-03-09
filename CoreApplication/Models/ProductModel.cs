namespace CoreApplication.Models
{
    [TableName("products")]
    public class ProductModel : AbstractModel<ProductModel>
    {
        public static IReadOnlyList<ProductModel> findAll()
        {
            return find(Tuple.Create("1", "=", "1" as object));
        }

        [TableColumn("id")]
        public int Id { get; set; }

        [TableColumn("external_id")]
        public string ExternalId { get; set; }

        [TableColumn("name")]
        public string Name { get; set; }

        [TableColumn("price")]
        public float Price { get; set; }

        [TableColumn("description")]
        public string Description { get; set; }

        [TableColumn("added_by")]
        public int AddedBy { get; set; }

        [TableColumn("created_at")]
        public DateTime CreatedAt { get; set; }

        [TableColumn("modified_at")]
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
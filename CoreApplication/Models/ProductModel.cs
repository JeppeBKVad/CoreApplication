namespace CoreApplication.Models
{
    public class products
    {
        public int Id { get; set; }
        public string External_id { get; set; }
        public string Name { get; set; }
        public float Price { get; set; }
        public string Description { get; set; }
        public int Added_by { get; set; }
        public DateTime Created_at { get; set; }
        public DateTime Modified_at { get; set; }
        public products(int id, string external_id, string name, float price, string description, int added_by, DateTime created_at, DateTime modified_at)
        {
            this.Id = id; 
            this.External_id = external_id;
            this.Name = name;
            this.Price = price;
            this.Description = description;
            this.Added_by = added_by;
            this.Created_at = created_at;
            this.Modified_at = modified_at;
        }         

    }
}
namespace CoreApplication.Models
{
    public class Sales
    {
        public int Id { get; set; }
        public int Product { get; set; }
        public int Amount { get; set; }
        public DateTime Sold_at { get; set; }
        public int Added_by { get; set; }
        public DateTime Create_at { get; set; }
        public DateTime Modified_at { get; set; }
        public Sales(int id, int product, int amount, DateTime sold_at, int added_by, DateTime create_at, DateTime modified_at)
        {
            this.Id = id;
            this.Product = product;
            this.Amount = amount;
            this.Sold_at = sold_at;
            this.Added_by = added_by;
            this.Create_at = create_at;
            this.Modified_at = modified_at;
        }
    }
}
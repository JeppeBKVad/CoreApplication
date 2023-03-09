namespace CoreApplication.Models
{
    public class Customer_sale
    {
        public int Id { get; set; }
        public int Customer { get; set; }
        public int Sales { get; set; }
        public DateTime Created_at { get; set; }
        public DateTime Modified_at { get; set; }
        public Customer_sale(int id, int customer, int sales, DateTime created_at, DateTime modified_at)
        {
            this.Id = id;
            this.Customer = customer;
            this.Sales = sales;
            this.Created_at = created_at;
            this.Modified_at = modified_at;
        }
    }
}
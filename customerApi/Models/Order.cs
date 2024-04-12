namespace acmeApi.Models
{
    public class Order
    {
        public int Id { get; set; }
        public int CustomerId { get; set; }
        public decimal TotalAmount { get; set; }
        public DateTime OrderDate { get; set; }
        // Other properties like order status, shipping address, etc.

        // Navigation property for customer
        public Customer Customer { get; set; }
    }
}

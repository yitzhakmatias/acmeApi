namespace acmeApi.Models
{
    public class Customer
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        // Other properties like address, phone number, etc.

        // Navigation property for orders
        public ICollection<Order> Orders { get; set; }
    }
}

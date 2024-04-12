using acmeApi.DbContexts;
using acmeApi.Models;
using acmeApi.utilities;
using Microsoft.EntityFrameworkCore;

namespace acmeApi.Services
{
    public class CustomerService(ApplicationDbContext context) : ICustomerService
    {
        public async Task<IEnumerable<Customer>> GetCustomersAsync()
        {
            return await context.Customers.ToListAsync();
        }

        public async Task<Customer> GetCustomerByIdAsync(int id)
        {
            return (await context.Customers.FindAsync(id))!;
        }

        public async Task CreateCustomerAsync(Customer customer)
        {
            if (customer == null)
            {
                throw new ArgumentNullException(nameof(customer));
            }

            context.Customers.Add(customer);
            await context.SaveChangesAsync();
        }

        public async Task UpdateCustomerAsync(Customer customer)
        {
            if (customer == null)
            {
                throw new ArgumentNullException(nameof(customer));
            }

            var existingCustomer = await context.Customers.FindAsync(customer.Id);
            if (existingCustomer == null)
            {
                throw new CustomerNotFoundException($"Customer with ID {customer.Id} not found.");
            }

            // Update customer properties
            existingCustomer.Name = customer.Name;
            existingCustomer.Email = customer.Email;
            // Update other properties as needed

            await context.SaveChangesAsync();
        }

        public async Task DeleteCustomerAsync(int id)
        {
            var customer = await context.Customers.FindAsync(id);
            if (customer == null)
            {
                throw new CustomerNotFoundException($"Customer with ID {id} not found.");
            }

            context.Customers.Remove(customer);
            await context.SaveChangesAsync();
        }
    }
}

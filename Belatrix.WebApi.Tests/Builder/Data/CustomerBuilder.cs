using Belatrix.WebApi.Models;
using Belatrix.WebApi.Repository.Postgresql;
using GenFu;

namespace Belatrix.WebApi.Tests.Builder.Data
{
    public partial class BelatrixDbContextBuilder
    {

        public BelatrixDbContextBuilder Add10Customers()
        {
            AddCustomers(_context, 10);
            return this;
        }

        public BelatrixDbContextBuilder Add1Customer()
        {
            AddCustomers(_context, 1);
            return this;
        }
        public BelatrixDbContextBuilder AddThisCustomer(Customer customer)
        {
            _context.Customers.Add(customer);
            _context.SaveChanges();
            return this;
        }
        private void AddCustomers(BelatrixDbContext context, int quantity)
        {
            var customerList = A.ListOf<Customer>(quantity);
            for (int i = 1; i <= quantity; i++)
            {
                customerList[i - 1].Id = i;
            }
            context.Customers.AddRange(customerList);
            context.SaveChanges();
        }
    }
}

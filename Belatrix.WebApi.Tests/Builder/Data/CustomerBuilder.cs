using Belatrix.WebApi.Models;
using Belatrix.WebApi.Repository.Postgresql;
using GenFu;

namespace Belatrix.WebApi.Tests.Builder.Data
{
    public partial class BelatrixDbContextBuilder
    {

        public BelatrixDbContextBuilder AddCustomers()
        {
            AddCustomers(_context);
            return this;
        }
        private void AddCustomers(BelatrixDbContext context)
        {
            var customerList = A.ListOf<Customer>(10);
            context.Customers.AddRange(customerList);
            context.SaveChanges();
        }
    }
}

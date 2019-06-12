using Belatrix.WebApi.Controllers;
using Belatrix.WebApi.Repository.Postgresql;
using Belatrix.WebApi.Tests.Builder.Data;
using FluentAssertions;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;
using Xunit;

namespace Belatrix.WebApi.Tests
{
    public class CustomerControllerTests
    {
        private readonly BelatrixDbContextBuilder _contextBuilder;

        public CustomerControllerTests(/*BelatrixDbContextBuilder contextBuilder*/)
        {
            _contextBuilder = new BelatrixDbContextBuilder();
        }

        [Fact]
        public async Task CustomerController_GetCustomer_Ok()
        {
            var db = _contextBuilder.ConfigureInMemory().Add10Customers().Build();
            var repository = new Repository<Models.Customer>(db);
            var controller = new CustomersController(repository);

            var response = (await controller.GetCustomers()).Result as OkObjectResult;

            var values = response.Value as List<Models.Customer>;
            values.Count.Should().Be(10);
        }

    }
}

using Belatrix.WebApi.Controllers;
using Belatrix.WebApi.Models;
using Belatrix.WebApi.Repository.Postgresql;
using Belatrix.WebApi.Tests.Builder.Data;
using FluentAssertions;
using GenFu;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Xunit;

namespace Belatrix.WebApi.Tests
{
    public class CustomerControllerTests
    {
        private readonly BelatrixDbContextBuilder _contextBuilder;

        public CustomerControllerTests()
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
        [Fact]
        public async Task CustomerController_GetCustomerById_Ok()
        {
            var db = _contextBuilder.ConfigureInMemory().Add1Customer().Build();
            var repository = new Repository<Models.Customer>(db);
            var controller = new CustomersController(repository);

            var response = (await controller.GetCustomerById(1)).Result as OkObjectResult;

            var values = response.Value as Models.Customer;
            values.Id.Should().Be(1);
        }
        [Fact]
        public async Task CustomerController_CreateCustomer_Ok()
        {
            var db = _contextBuilder.ConfigureInMemory().Build();
            var repository = new Repository<Models.Customer>(db);
            var controller = new CustomersController(repository);
            var request = A.New<Customer>();
            var response = (await controller.CreateCustomer(request)).Result as OkObjectResult;

            var values = Convert.ToInt32(response.Value);
            values.Should().Be(request.Id);
        }

        [Fact]
        public async Task CustomerController_UpdateCustomer_Ok()
        {
            var customer = A.New<Customer>();
            var db = _contextBuilder.ConfigureInMemory().AddThisCustomer(customer).Build();
            var repository = new Repository<Models.Customer>(db);
            var controller = new CustomersController(repository);

            var response = (await controller.UpdateCustomer(customer)).Result as OkObjectResult;

            var values = (bool)response.Value;
            values.Should().BeTrue();
        }

        [Fact]
        public async Task CustomerController_DeleteCustomer_Ok()
        {        
            var db = _contextBuilder.ConfigureInMemory().Add1Customer().Build();
            var repository = new Repository<Models.Customer>(db);
            var controller = new CustomersController(repository);
            
            var response = (await controller.DeleteCustomer(1)).Result as OkObjectResult;

            var values = (bool)response.Value;
            values.Should().BeTrue();
        }
    }
}

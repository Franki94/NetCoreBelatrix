using Belatrix.WebApi.Models;
using Belatrix.WebApi.Repository;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Belatrix.WebApi.Controllers
{
    [Route("Api/customers")]
    [ApiController]
    public class CustomersController : Controller
    {
        private readonly IRepository<Customer> _customerRepository;
        public CustomersController(IRepository<Customer> customerRepository)
        {
            _customerRepository = customerRepository;
        }
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Customer>>> GetCustomers()
        {
            var customers = await _customerRepository.Read();
            return Ok(customers);
        }
    
        [HttpPut]
        public async Task<bool> UpdateCustomer(Customer customer)
        {
            var customersResult = await _customerRepository.Update(customer);
            return customersResult;
        }
    }
}
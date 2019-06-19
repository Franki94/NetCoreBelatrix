using Belatrix.WebApi.Filters;
using Belatrix.WebApi.Models;
using Belatrix.WebApi.Repository;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Belatrix.WebApi.Controllers
{
    [Route("api/customers")]
    [ApiController]
    public class CustomersController : Controller
    {
        private readonly IRepository<Customer> _customerRepository;
        public CustomersController(IRepository<Customer> customerRepository)
        {
            _customerRepository = customerRepository;
        }
        [CustomerResultFilter]
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ViewModels.Customer>>> GetCustomers()
        {
            var customers = await _customerRepository.Read();
            return Ok(customers);
        }

        [HttpGet("{id:int}")]
        public async Task<ActionResult<Customer>> GetCustomerById(int id)
        {
            var customers = await _customerRepository.ReadById(id);
            return Ok(customers);
        }
        [HttpPut]
        public async Task<ActionResult<bool>> UpdateCustomer([FromBody] Customer customer)
        {
            var customersResult = await _customerRepository.Update(customer);
            return Ok(customersResult);
        }
        [HttpPost]
        public async Task<ActionResult<int>> CreateCustomer([FromBody] Customer customer)
        {
            var customersResult = await _customerRepository.Create(customer);
            return Ok(customer.Id);
        }
        [HttpDelete("{id}")]
        public async Task<ActionResult<bool>> DeleteCustomer(int id)
        {
            var customer = await _customerRepository.ReadById(id);
            var customersResult = await _customerRepository.Delete(customer);
            return Ok(customersResult);
        }
    }
}
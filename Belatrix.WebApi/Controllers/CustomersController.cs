using Belatrix.WebApi.Models;
using Belatrix.WebApi.Repository;
using Microsoft.AspNetCore.Mvc;
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
        public async Task<IActionResult> GetCustomer()
        {
            var customers = await _customerRepository.Read();
            return Ok(customers);
        }
    }
}
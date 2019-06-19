using Belatrix.WebApi.Models;
using Belatrix.WebApi.Repository;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Belatrix.WebApi.Controllers
{
    [Route("api/order")]
    [ApiController]
    public class OrderController : Controller
    {
        private readonly IRepository<Order> _repository;
        public OrderController(IRepository<Order> repository)
        {
            _repository = repository;
        }
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Order>>> GetOrders()
        {
            var ordersResult = await _repository.Read();
            return Ok(ordersResult);
        }

        [HttpGet("{id:int}")]
        public async Task<ActionResult<Order>> GetOrderById(int id)
        {
            var orderResult = await _repository.ReadById(id);
            return Ok(orderResult);
        }
        [HttpPut]
        public async Task<ActionResult<bool>> UpdateOrder([FromBody] Order order)
        {
            var orderResult = await _repository.Update(order);
            return Ok(orderResult);
        }
        [HttpPost]
        public async Task<ActionResult<int>> CreateOrder([FromBody] Order order)
        {
            var customersResult = await _repository.Create(order);
            return Ok(order.Id);
        }
        [HttpDelete("{id}")]
        public async Task<ActionResult<bool>> DeleteOrder(int id)
        {
            var order = await _repository.ReadById(id);
            var orderResult = await _repository.Delete(order);
            return Ok(orderResult);
        }
    }
}
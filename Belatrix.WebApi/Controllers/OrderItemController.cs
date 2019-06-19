using Belatrix.WebApi.Models;
using Belatrix.WebApi.Repository;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Belatrix.WebApi.Controllers
{
    public class OrderItemController : Controller
    {
        private readonly IRepository<OrderItem> _repository;

        public OrderItemController(IRepository<OrderItem> repository)
        {
            _repository = repository;
        }
        [HttpGet]
        public async Task<ActionResult<IEnumerable<OrderItem>>> GetOrderItems()
        {
            var ordersResult = await _repository.Read();
            return Ok(ordersResult);
        }

        [HttpGet("{id:int}")]
        public async Task<ActionResult<OrderItem>> GetOrderItemById(int id)
        {
            var orderItemResult = await _repository.ReadById(id);
            return Ok(orderItemResult);
        }
        [HttpPut]
        public async Task<ActionResult<bool>> UpdateOrderItem([FromBody] OrderItem orderItem)
        {
            var orderItemResult = await _repository.Update(orderItem);
            return Ok(orderItemResult);
        }
        [HttpPost]
        public async Task<ActionResult<int>> CreateOrderItem([FromBody] OrderItem orderItem)
        {
            var orderItemResult = await _repository.Create(orderItem);
            return Ok(orderItem.Id);
        }
        [HttpDelete("{id}")]
        public async Task<ActionResult<bool>> DeleteOrderItem(int id)
        {
            var orderItem = await _repository.ReadById(id);
            var orderItemResult = await _repository.Delete(orderItem);
            return Ok(orderItemResult);
        }
    }
}
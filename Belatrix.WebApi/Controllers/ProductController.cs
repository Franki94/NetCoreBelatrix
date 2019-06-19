using Belatrix.WebApi.Models;
using Belatrix.WebApi.Repository;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Belatrix.WebApi.Controllers
{
    public class ProductController : Controller
    {
        private readonly IRepository<Product> _repository;

        public ProductController(IRepository<Product> repository)
        {
            _repository = repository;
        }
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Product>>> GetProducts()
        {
            var productsResult = await _repository.Read();
            return Ok(productsResult);
        }

        [HttpGet("{id:int}")]
        public async Task<ActionResult<Product>> GetProductById(int id)
        {
            var productResult = await _repository.ReadById(id);
            return Ok(productResult);
        }
        [HttpPut]
        public async Task<ActionResult<bool>> UpdateProduct([FromBody] Product product)
        {
            var productResult = await _repository.Update(product);
            return Ok(productResult);
        }
        [HttpPost]
        public async Task<ActionResult<int>> CreateProduct([FromBody] Product product)
        {
            var productResult = await _repository.Create(product);
            return Ok(product.Id);
        }
        [HttpDelete("{id}")]
        public async Task<ActionResult<bool>> DeleteProduct(int id)
        {
            var product = await _repository.ReadById(id);
            var productResult = await _repository.Delete(product);
            return Ok(productResult);
        }
    }
}
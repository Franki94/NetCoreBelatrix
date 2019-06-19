using Belatrix.WebApi.Models;
using Belatrix.WebApi.Repository;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Belatrix.WebApi.Controllers
{

    [Route("api/suppliers")]
    [ApiController]
    public class SupplierController : Controller
    {
        private readonly IRepository<Supplier> _repository;
        public SupplierController(IRepository<Supplier> repository)
        {
            _repository = repository;
        }
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Supplier>>> GetSuppliers()
        {
            var suppliersResult = await _repository.Read();
            return Ok(suppliersResult);
        }

        [HttpGet("{id:int}")]
        public async Task<ActionResult<Supplier>> GetSupplierById(int id)
        {
            var supplierResult = await _repository.ReadById(id);
            return Ok(supplierResult);
        }
        [HttpPut]
        public async Task<ActionResult<bool>> UpdateSupplier([FromBody] Supplier supplier)
        {
            var supplierResult = await _repository.Update(supplier);
            return Ok(supplierResult);
        }
        [HttpPost]
        public async Task<ActionResult<int>> CreateSupplier([FromBody] Supplier supplier)
        {
            var supplierResult = await _repository.Create(supplier);
            return Ok(supplier.Id);
        }
        [HttpDelete("{id}")]
        public async Task<ActionResult<bool>> DeleteSupplier(int id)
        {
            var supplier = await _repository.ReadById(id);
            var supplierResult = await _repository.Delete(supplier);
            return Ok(supplierResult);
        }
    }
}
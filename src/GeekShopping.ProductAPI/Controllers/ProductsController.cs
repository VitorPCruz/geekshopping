using GeekShopping.ProductAPI.Controllers.Base;
using GeekShopping.ProductAPI.Data.ValueObjects;
using GeekShopping.ProductAPI.Repository.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace GeekShopping.ProductAPI.Controllers
{
    public class ProductsController : MainController
    {
        private readonly IProductRepository _repository;

        public ProductsController(IProductRepository repository) =>
            _repository = repository ?? throw new ArgumentNullException(nameof(repository));

        [HttpGet]
        public async Task<ActionResult<IEnumerable<ProductVO>>> FindAll(long id)
        {
            return Ok(await _repository.FindAll());
        }

        [HttpGet("{id:int}")]
        public async Task<IActionResult> FindById(long id)
        {
            var product = await _repository.FindById(id);
            if (product == null) return NotFound();
            return Ok(product);
        }

        [HttpPost]
        public async Task<ActionResult<ProductVO>> Create(ProductVO productVO)
        {
            if (productVO == null) return BadRequest();
            var product = await _repository.Create(productVO);
            return Ok(product);
        }

        [HttpPut]
        public async Task<ActionResult<ProductVO>> Update(ProductVO productVO)
        {
            if (productVO == null) return BadRequest();
            var product = await _repository.Update(productVO);
            return Ok(product);
        }

        [HttpDelete("{id:int}")]
        public async Task<ActionResult> Delete(long id)
        {
            var status = await _repository.Delete(id);
            if (!status) return BadRequest();
            return Ok();
        }
    }
}

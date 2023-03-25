using Microsoft.AspNetCore.Mvc;
using GeekShopping.ProductAPI.Repository;
using GeekShopping.ProductAPI.Data.ValueObjects;

namespace GeekShopping.ProductAPIController.Controllers
{
    [ApiController]
    [Route("api/v1/[controller]")]
    public class ProductAPIController : ControllerBase
    {
        private IProductRepository _repository;

        public ProductAPIController(IProductRepository repository)
        {
            _repository = repository ?? 
                throw new ArgumentNullException(nameof(repository));
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<ProductVO>>> FindAll()
        {
            var product = await _repository.FindAll();
            return Ok(product);
        }
        [HttpGet("{id}")]
        public async Task<ActionResult<ProductVO>> FindById(long id)
        {
            var product = await _repository.FindById(id);
            if (product.Id <= 0) return NotFound();
            return Ok(product);
        }
    }
}
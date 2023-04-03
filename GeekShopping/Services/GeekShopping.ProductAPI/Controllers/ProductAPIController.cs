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
        [Authorize]
        public async Task<ActionResult<IEnumerable<ProductVO>>> FindAll()
        {
            var product = await _repository.FindAll();
            return Ok(product);
        }
        [HttpGet("{id}")]
        [Authorize]
        public async Task<ActionResult<ProductVO>> FindById(long id)
        {
            Console.WriteLine("Calling FindId API");
            var product = await _repository.FindById(id);
            if (product.Id <= 0) return NotFound();
            return Ok(product);
        }
        [HttpPost]
        [Authorize]
        public async Task<ActionResult<ProductVO>> Create([FromBody] ProductVO vo)
        {
            Console.WriteLine("Calling Create API");
            if (vo == null) return BadRequest();
            var product = await _repository.Create(vo);
            
            return Ok(product);
        }
        [HttpPut]
        [Authorize]
        public async Task<ActionResult<ProductVO>> Update([FromBody] ProductVO vo)
        {
            if (vo == null) return BadRequest();
            var product = await _repository.Update(vo);
            
            return Ok(product);
        }
        [HttpDelete("{id}")]
        [Authorize(Roles = Role.Admin)]
        public async Task<ActionResult> Delete(long id)
        {
            Console.WriteLine("Caling Delete API");
            var status = await _repository.Delete(id);
            if (!status) return BadRequest();
            return Ok(status);
        }
    }
}
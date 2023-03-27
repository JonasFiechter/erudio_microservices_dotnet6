using Microsoft.AspNetCore.Mvc;
using GeekShopping.Web.Services.IServices;

namespace GeekShopping.Web.Controllers
{
    public class ProductController : Controller
    {
        private readonly IProductService _productService;

        public ProductController(IProductService productService)
        {
            _productService = productService ?? throw 
                new ArgumentException(nameof(productService));
        }
        public async Task<IActionResult> ProductIndex()
        {
            var products = await _productService.FindAllProducts();
            return View(products);
        }
    }
}
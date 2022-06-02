using Business.Abstract;
using Entities.Concrete;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        IProductService _productService;
        public ProductsController(IProductService productService)
        {
            _productService = productService;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            var result = _productService.GetAll();
            return Ok(result);
        }

        [HttpPost]
        public IActionResult Add(Product product)
        {
            if (product is null) { return BadRequest(); }

            _productService.Add(product);
            return Ok();
        }

        [HttpDelete]
        public IActionResult Delete(Product product)
        {
            _productService.Delete(product);
            return Ok();
        }

        [HttpPut]
        public IActionResult Update(Product product)
        {
            _productService.Update(product);
            return Ok();
        }
    }
}
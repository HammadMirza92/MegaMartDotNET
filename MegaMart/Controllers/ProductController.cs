using MegaMart.Entity;
using MegaMart.Repo.IRepository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace MegaMart.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IProductRepository _productRepository;
        public ProductController(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        // GET: api/product
        [HttpGet]
        /*[ResponseCache(Duration = 120)]*/
        public async Task<ActionResult<Product>> Get()
        {
            var products = await _productRepository.GetAll();
            if (!products.Any())
            {
                return BadRequest("Ooops ! No Product Found");
            }
            return Ok(products);

        }
      


    }
}

using MegaMart.Entity;
using MegaMart.Repo.IRepository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace MegaMart.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        private readonly IProductRepository _productRepository;
        private readonly ICategoryRepository _categoryRepository;
        public CategoryController(IProductRepository productRepository, ICategoryRepository categoryRepository)
        {
            _productRepository = productRepository;
            _categoryRepository = categoryRepository;

        }

        // GET: api/product
        [HttpGet]
        /*[ResponseCache(Duration = 120)]*/
        public async Task<ActionResult<Category>> GetAll()
        {
            var category = await _categoryRepository.GetAll();
            if (!category.Any())
            {
                return BadRequest("Ooops ! No Category Found");
            }
            return Ok(category);
        }
    }
}

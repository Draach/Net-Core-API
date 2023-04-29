using Microsoft.AspNetCore.Mvc;
using RestAPI.Domain.Categories;
using RestAPI.Domain.Products;
using RestAPI.Infrastructure.Repositories;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace RestAPI.Controllers
{
    [Route("api/products")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly ProductsRepository _productsRepository;
        private readonly CategoriesRepository _categoriesRepository;

        public ProductsController(ILogger<ProductsController> logger, ProductsRepository productsRepository, CategoriesRepository categoriesRepository)
        {
            _productsRepository = productsRepository;
            _categoriesRepository = categoriesRepository;
        }

        // GET: api/<ProductsController>
        [HttpGet]
        public ActionResult<IEnumerable<ProductDto>> Get()
        {
            List<ProductDto> productDtos = new List<ProductDto>();
            var products = _productsRepository.GetAll();

            foreach (var product in products)
            {
                productDtos.Add(new ProductDto()
                {
                    Id = product.Id,
                    Name = product.Name,
                    Description = product.Description,
                    Price = product.Price,
                });
            }
            return productDtos;
        }

        // GET api/<ProductsController>/5
        [HttpGet("{id}")]
        public ActionResult<ProductWithCategoriesDto> Get(Guid id)
        {
            ActionResult result;
            if (id == Guid.Empty)
            {
                result = BadRequest();
            }
            else
            {
                Product product = _productsRepository.GetById(id);
                if (product is not null)
                {
                    List<CategoryDto> categoriesDtos = new List<CategoryDto>();
                    foreach (var category in product.Categories)
                    {
                        categoriesDtos.Add(new CategoryDto()
                        {
                            Id = category.Id,
                            Name = category.Name,
                        });
                    }
                    result = Ok(new ProductWithCategoriesDto()
                    {
                        Id = product.Id,
                        Name = product.Name,
                        Description = product.Description,
                        Price = product.Price,
                        CategoriesDtos = categoriesDtos,
                    });
                }
                else
                    result = NotFound();
            }
            return result;
        }

        // POST api/<ProductsController>
        [HttpPost]
        [ProducesResponseType(typeof(ProductDto), 201)]
        [ProducesResponseType(typeof(ProductDto), 400)]
        [ProducesResponseType(typeof(ProductDto), 500)]
        public ActionResult<ProductDto> Post([FromBody] ProductCreateDto productDto)
        {
            ActionResult result;
            if (productDto == null)
            {
                result = BadRequest();
            }
            else if (productDto.Name == "Coca")
            {
                ModelState.AddModelError("ExistingName", "There is already an existing product with that name.");
                return BadRequest(ModelState);
            }
            else
            {
                if (productDto.CategoriesIds.Count > 0)
                {
                    Product product = new Product(productDto);
                    foreach (var categoryId in productDto.CategoriesIds)
                    {
                        product.Categories.Add(_categoriesRepository.GetById(categoryId));
                    }
                    result = CreatedAtRoute("", _productsRepository.Add(product));
                }
                else
                {
                    Product product = new Product(productDto);
                    result = CreatedAtRoute("", _productsRepository.Add(product));
                }
            }


            return result;
        }

        // PUT api/<ProductsController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<ProductsController>/5
        [HttpDelete("{id}")]
        public ActionResult Delete(Guid id)
        {
            bool result = _productsRepository.Delete(id);
            if (!result) return NotFound();

            return NoContent();
        }
    }
}

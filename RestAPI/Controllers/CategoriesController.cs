using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using RestAPI.Domain.Categories;
using RestAPI.Domain.Products;
using RestAPI.Infrastructure.Repositories;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace RestAPI.Controllers
{
    [Route("api/categories")]
    [ApiController]
    public class CategoriesController : ControllerBase
    {
        private readonly CategoriesRepository _categoriesRepository;

        public CategoriesController(CategoriesRepository categoriesRepository)
        {
            _categoriesRepository = categoriesRepository;
        }

        // GET: api/<CategoriesController>
        [HttpGet]
        public async Task<ActionResult<IEnumerable<CategoryDto>>> Get()
        {
            List<CategoryDto> responseCategories = new List<CategoryDto>();

            List<Category> categories = (List<Category>)await _categoriesRepository.GetAll();

            foreach (Category category in categories)
            {
                responseCategories.Add(new CategoryDto()
                {
                    Id = category.Id,
                    Name = category.Name,
                });
            }

            return Ok(responseCategories);
        }

        // GET api/<CategoriesController>/5
        [HttpGet("{id}")]
        public async Task<ActionResult<CategoryWithProducts>> Get(Guid id)
        {
            ActionResult result;
            if (id == Guid.Empty)
            {
                result = BadRequest();
            }
            else
            {
                Category category = await _categoriesRepository.GetById(id);
                if (category is not null)
                {
                    List<ProductDto> productDtos = new List<ProductDto>();
                    foreach (var product in category.Products)
                    {
                        productDtos.Add(new ProductDto()
                        {
                            Id = product.Id,
                            Name = product.Name,
                            Description = product.Description,
                            Price = product.Price,
                        });
                    }
                    result = Ok(new CategoryWithProducts()
                    {
                        Id = category.Id,
                        Name = category.Name,
                        ProductDtos = productDtos,
                    });
                }
                else
                    result = NotFound();
            }
            return result;
        }

        // POST api/<CategoriesController>
        [HttpPost]
        public async Task<ActionResult<CategoryDto>> Post([FromBody] CategoryCreateDto categoryCreateDto)
        {
            ActionResult result;
            if (categoryCreateDto == null)
            {
                result = BadRequest();
            }
            else
            {
                CategoryDto newCategoryDto = new CategoryDto()
                {
                    Name = categoryCreateDto.Name,
                };

                Category newCategory = new Category(newCategoryDto);

                await _categoriesRepository.Add(newCategory);
                result = CreatedAtRoute("", newCategory);
            }


            return result;
        }

        // PUT api/<CategoriesController>/5
        [HttpPut("{id}")]
        public async Task Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<CategoriesController>/5
        [HttpDelete("{id}")]
        [Authorize]
        [ProducesResponseType(typeof(void), 401)]
        public async Task<ActionResult> Delete(Guid id)
        {
            bool result = await _categoriesRepository.Delete(id);
            if (!result) return NotFound();

            return NoContent();
        }
    }
}

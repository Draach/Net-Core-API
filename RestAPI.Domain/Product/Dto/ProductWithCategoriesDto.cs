using RestAPI.Domain.Categories;

namespace RestAPI.Domain.Products
{
    public class ProductWithCategoriesDto
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public IList<CategoryDto> CategoriesDtos { get; set; }
        public double Price { get; set; }
    }
}

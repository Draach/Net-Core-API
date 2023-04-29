using RestAPI.Domain.Products;

namespace RestAPI.Domain.Categories
{
    public class CategoryWithProducts
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public IList<ProductDto> ProductDtos { get; set; }
    }
}

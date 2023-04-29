using RestAPI.Domain.Products;

namespace RestAPI.Domain.Categories
{
    public record CategoryDto
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
    }
}

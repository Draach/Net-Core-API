using RestAPI.Domain.Categories;
using System.ComponentModel.DataAnnotations;

namespace RestAPI.Domain.Products
{
    public record ProductDto
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public double Price { get; set; }
    }
}

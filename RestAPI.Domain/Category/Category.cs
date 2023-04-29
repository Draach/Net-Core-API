using RestAPI.Domain.Products;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace RestAPI.Domain.Categories
{
    public class Category : ICategory
    {
        [Key]
        public Guid Id { get; private set; }
        [Required]
        [StringLength(50)]
        public string Name { get; private set; }
        public virtual IList<Product> Products { get; private set; }

        private Category() { }
        public Category(CategoryDto categoryDto)
        {
            Id = Guid.NewGuid();
            Name = categoryDto.Name;
            Products = new List<Product>();
        }
    }
}

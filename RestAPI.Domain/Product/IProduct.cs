using RestAPI.Domain.Categories;
using System.ComponentModel.DataAnnotations;

namespace RestAPI.Domain.Products
{
    public interface IProduct
    {
        [Key]
        Guid Id { get; }
        [Required]
        [StringLength(100)]
        string Name { get; }
        [Required]
        [StringLength(200)]
        string Description { get; }
        IList<Category> Categories { get; }
        [Required]
        double Price { get; }
    }
}

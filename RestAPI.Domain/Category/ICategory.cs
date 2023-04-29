using RestAPI.Domain.Products;

namespace RestAPI.Domain.Categories
{
    public interface ICategory
    {
        Guid Id { get; }
        string Name { get; }
        IList<Product> Products { get; }
    }
}

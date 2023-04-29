using RestAPI.Domain.Categories;

namespace RestAPI.Domain.Products
{
    public class Product : IProduct
    {
        public Guid Id { get; private set; }
        public string Name { get; private set; }
        public string Description { get; private set; }
        public virtual IList<Category> Categories { get; private set; }
        public double Price { get; private set; }

        private Product() { }
        public Product(ProductCreateDto product)
        {
            Id = Guid.NewGuid();
            Name = product.Name;
            Description = product.Description;
            Price = product.Price;
            Categories = new List<Category>();
        }
    }
}

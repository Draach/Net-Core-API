namespace RestAPI.Domain.Products
{
    public class ProductCreateDto
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public IList<Guid> CategoriesIds { get; set; }
        public double Price { get; set; }
    }
}

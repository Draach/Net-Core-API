namespace RestAPI.Domain.Products
{
    public record ProductCreateDto
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public IList<Guid> CategoriesIds { get; set; }
        public double Price { get; set; }
    }
}

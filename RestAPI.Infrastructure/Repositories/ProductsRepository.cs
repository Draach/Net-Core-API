using Microsoft.EntityFrameworkCore;
using RestAPI.Domain.Products;
using RestAPI.Domain.Repository;

namespace RestAPI.Infrastructure.Repositories
{
    public class ProductsRepository : IRepository<Product, Guid>
    {
        private readonly ECommerceDBContext _context;
        public ProductsRepository(ECommerceDBContext eCommerceDBContext)
        {
            _context = eCommerceDBContext;
        }

        public Product Add(Product entity)
        {
            _context.Add(entity);
            _context.SaveChanges();
            return entity;
        }

        public bool Delete(Guid guid)
        {
            bool opResult = false;
            Product product = _context.Products.Where(p => p.Id == guid).FirstOrDefault();
            if (product != null)
            {
                _context.Remove(product);
                _context.SaveChanges();
                opResult = true;
            }
            return opResult;
        }

        public IEnumerable<Product> GetAll()
        {
            return _context.Products.ToList();
        }

        public Product GetById(Guid guid)
        {
            return _context.Products.Include(p => p.Categories).FirstOrDefault(p => p.Id == guid);
        }

        public Product Update(Product entity)
        {
            throw new NotImplementedException();
        }
    }
}

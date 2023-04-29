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

        public async Task<Product> Add(Product entity)
        {
            await _context.Products.AddAsync(entity);
            await _context.SaveChangesAsync();
            return entity;
        }

        public async Task<bool> Delete(Guid guid)
        {
            bool opResult = false;
            Product product = await _context.Products.Where(p => p.Id == guid).FirstOrDefaultAsync();
            if (product != null)
            {
                _context.Products.Remove(product);
                await _context.SaveChangesAsync();
                opResult = true;
            }
            return opResult;
        }

        public async Task<IEnumerable<Product>> GetAll()
        {
            return await _context.Products.ToListAsync();
        }

        public async Task<Product> GetById(Guid guid)
        {
            return await _context.Products.Include(p => p.Categories).FirstOrDefaultAsync(p => p.Id == guid);
        }

        public async Task<Product> Update(Product entity)
        {
            throw new NotImplementedException();
        }
    }
}

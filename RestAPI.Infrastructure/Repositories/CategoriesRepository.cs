using Microsoft.EntityFrameworkCore;
using RestAPI.Domain.Categories;
using RestAPI.Domain.Repository;

namespace RestAPI.Infrastructure.Repositories
{
    public class CategoriesRepository : IRepository<Category, Guid>
    {
        private readonly ECommerceDBContext _context;
        public CategoriesRepository(ECommerceDBContext context)
        {
            _context = context;
        }
        public async Task<Category> Add(Category entity)
        {
            await _context.Categories.AddAsync(entity);
            await _context.SaveChangesAsync();
            return entity;
        }

        public async Task<bool> Delete(Guid guid)
        {
            bool opResult = false;
            Category category = await _context.Categories.FirstOrDefaultAsync(c => c.Id == guid);
            if (category is not null)
            {
                _context.Categories.Remove(category);
                await _context.SaveChangesAsync();
                opResult = true;
            }
            return opResult;
        }

        public async Task<IEnumerable<Category>> GetAll()
        {
            return await _context.Categories.ToListAsync();
        }

        public async Task<Category> GetById(Guid guid)
        {
            return await _context.Categories.Include(c => c.Products).FirstOrDefaultAsync(c => c.Id == guid);
        }

        public async Task<Category> Update(Category entity)
        {
            throw new NotImplementedException();
        }
    }
}

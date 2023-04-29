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
        public Category Add(Category entity)
        {
            _context.Categories.Add(entity);
            _context.SaveChanges();
            return entity;
        }

        public bool Delete(Guid guid)
        {
            bool opResult = false;
            Category category = _context.Categories.FirstOrDefault(c => c.Id == guid);
            if (category is not null)
            {
                _context.Remove(category);
                _context.SaveChanges();
                opResult = true;
            }
            return opResult;
        }

        public IEnumerable<Category> GetAll()
        {
            return _context.Categories.ToList();
        }

        public Category GetById(Guid guid)
        {
            return _context.Categories.Include(c => c.Products).FirstOrDefault(c => c.Id == guid);
        }

        public Category Update(Category entity)
        {
            throw new NotImplementedException();
        }
    }
}

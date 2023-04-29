using Microsoft.EntityFrameworkCore;
using RestAPI.Domain.Repository;
using RestAPI.Domain.Users;

namespace RestAPI.Infrastructure.Repositories
{
    public class UsersRepository : IRepository<User, int>
    {
        private readonly ECommerceDBContext _context;
        public UsersRepository(ECommerceDBContext eCommerceDBContext)
        {
            _context = eCommerceDBContext;
        }

        public async Task<User> Add(User entity)
        {
            await _context.Users.AddAsync(entity);
            await _context.SaveChangesAsync();
            return entity;
        }

        public async Task<bool> Delete(int id)
        {
            bool opResult = false;
            User user = await _context.Users.FirstOrDefaultAsync(u => u.Id == id);
            if (user != null)
            {
                _context.Users.Remove(user);
                await _context.SaveChangesAsync();
                opResult = true;
            }
            return opResult;
        }

        public async Task<IEnumerable<User>> GetAll()
        {
            return await _context.Users.ToListAsync();
        }

        public async Task<User> GetById(int id)
        {
            return await _context.Users.FirstOrDefaultAsync(u => u.Id == id);
        }

        public async Task<User> GetByUserName(string userName)
        {
            return await _context.Users.FirstOrDefaultAsync(u => u.UserName == userName);
        }

        public async Task<User> Update(User entity)
        {
            throw new NotImplementedException();
        }
    }
}

using Microsoft.EntityFrameworkCore;
using Store.Domain.Entities;
using Store.Domain.Repositories;
using Store.Infra.Data.Context;

namespace Store.Infra.Data.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly StoreContext _context;

        public UserRepository(StoreContext context)
        {
            _context = context;
        }

        public async Task<User> CreateUserAsync(User user)
        {
            _context.Add(user);
            await _context.SaveChangesAsync();
            return user;
        }

        public async Task DeleteAsync(User user)
        {
            _context.Remove(user);
            await _context.SaveChangesAsync();
        }

        public async Task<User> GetByIdAsync(int id)
        {
            return await _context.User.FirstOrDefaultAsync(f => f.UserId == id);
        }

        public async Task<ICollection<User>> GetPeopleAsync()
        {
            return await _context.User.ToListAsync();
        }

        public async Task UpdateAsync(User user)
        {
            _context.Update(user);
            await _context.SaveChangesAsync();
        }

        public async Task<int> GetIdByDocumentAsync(string document)
        {
            return (await _context.User.FirstOrDefaultAsync(f => f.Name == document))?.UserId ?? 0;
        }
    }
}

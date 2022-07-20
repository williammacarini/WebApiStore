using Microsoft.EntityFrameworkCore;
using Store.Domain.Entities;
using Store.Domain.Repositories;
using Store.Infra.Data.Context;

namespace Store.Infra.Data.Repositories
{
    public class UserAuthenticationRepository : IUserAuthenticationRepository
    {
        private readonly StoreContext _storeContext;

        public UserAuthenticationRepository(StoreContext storeContext)
        {
            _storeContext = storeContext;
        }

        public async Task<UserAuthentication> GetUserByEmailAndPassword(string email, string password)
        {
            return await _storeContext.UserAuthentication.FirstOrDefaultAsync(x => x.Email == email && x.Password == password);
        }
    }
}

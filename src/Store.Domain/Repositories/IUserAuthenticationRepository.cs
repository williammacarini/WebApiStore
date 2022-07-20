using Store.Domain.Entities;

namespace Store.Domain.Repositories
{
    public interface IUserAuthenticationRepository
    {
        Task<UserAuthentication> GetUserByEmailAndPassword(string email, string password);
    }
}

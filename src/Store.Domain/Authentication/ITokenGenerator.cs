using Store.Domain.Entities;

namespace Store.Domain.Authentication
{
    public interface ITokenGenerator
    {
        dynamic GenerateToken(UserAuthentication userAuthentication);
    }
}

using Store.Service.DTOs;

namespace Store.Service.Services.Interfaces
{
    public interface IUserAuthenticationService
    {
        Task<ResultService<dynamic>> GenerateTokenAsync(UserAuthenticationDto userAuthenticationDto);
    }
}

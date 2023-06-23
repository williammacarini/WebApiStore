using Store.Domain.FilterDB;
using Store.Service.DTOs;

namespace Store.Service.Services.Interfaces
{
    public interface IUserService
    {
        Task<ResultService<UserDto>> CreateAsync(UserDto userDTO);
        Task<ResultService<ICollection<UserDto>>> GetUserAsync();
        Task<ResultService<UserDto>> GetUserByIdAsync(int userId);
        Task<ResultService> UpdateUserAsync(UserDto userDTO);
        Task<ResultService> DeleteUserAsync(int userId);
        Task<ResultService<PagedBaseResponseDto<UserDto>>> GetPagedUserAsync(UserFilterDb userFilterDb);
    }
}

using Store.Domain.FilterDB;
using Store.Service.DTOs;

namespace Store.Service.Services.Interfaces
{
    public interface IUserService
    {
        Task<ResultService<UserDTO>> CreateAsync(UserDTO userDTO);
        Task<ResultService<ICollection<UserDTO>>> GetUserAsync();
        Task<ResultService<UserDTO>> GetUserByIdAsync(int userId);
        Task<ResultService> UpdateUserAsync(UserDTO userDTO);
        Task<ResultService> DeleteUserAsync(int userId);
        Task<ResultService<PagedBaseResponseDTO<UserDTO>>> GetPagedUserAsync(UserFilterDb userFilterDb);
    }
}

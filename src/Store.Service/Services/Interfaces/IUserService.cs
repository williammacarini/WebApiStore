using Store.Service.DTOs;

namespace Store.Service.Services.Interfaces
{
    public interface IUserService
    {
        Task<ResultService<UserDTO>> CreateAsync(UserDTO userDTO);
        Task<ResultService<ICollection<UserDTO>>> GetPeopleAsync();
        Task<ResultService<UserDTO>> GetByIdAsync(int id);
    }
}

using AutoMapper;
using Store.Domain.Entities;
using Store.Domain.FilterDB;
using Store.Domain.Repositories;
using Store.Service.DTOs;
using Store.Service.DTOs.Validations;
using Store.Service.Services.Interfaces;

namespace Store.Service.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;
        private readonly IMapper _mapper;
        public UserService(IUserRepository userRepository, IMapper mapper)
        {
            _userRepository = userRepository;
            _mapper = mapper;
        }

        public async Task<ResultService<UserDto>> CreateAsync(UserDto userDto)
        {
            if (userDto == null)
                return ResultService.Fail<UserDto>("Deve ser informado o usuário!");

            var result = new UserDtoValidator().Validate(userDto);

            if (!result.IsValid)
                return ResultService.RequestError<UserDto>("Os campos estão incorretos!", result);

            var user = _mapper.Map<User>(userDto);
            var data = await _userRepository.CreateUserAsync(user);
            return ResultService.Ok(_mapper.Map<UserDto>(data));
        }

        public async Task<ResultService<ICollection<UserDto>>> GetUserAsync()
        {
            var people = await _userRepository.GetPeopleAsync();
            if (people == null)
                return ResultService.Fail<ICollection<UserDto>>("Usuários não encontrados!");
            return ResultService.Ok(_mapper.Map<ICollection<UserDto>>(people));
        }

        public async Task<ResultService<UserDto>> GetUserByIdAsync(int userId)
        {
            var person = await _userRepository.GetByIdAsync(userId);
            if (person == null)
                return ResultService.Fail<UserDto>("Usuário não encontrados!");
            return ResultService.Ok(_mapper.Map<UserDto>(person));
        }

        public async Task<ResultService> UpdateUserAsync(UserDto userDTO)
        {
            if (userDTO == null)
                return ResultService.Fail("Objeto deve ser informado!");

            var userValidation = new UserDtoValidator().Validate(userDTO);

            if (!userValidation.IsValid)
                return ResultService.RequestError("Erro na validação dos campos!", userValidation);

            var user = await _userRepository.GetByIdAsync(userDTO.UserId);

            if (user == null)
                return ResultService.Fail("Usuário não encontrado!");

            user = _mapper.Map(userDTO, user);
            await _userRepository.UpdateAsync(user);
            return ResultService.Ok("Usuário atualizado!");
        }

        public async Task<ResultService> DeleteUserAsync(int userId)
        {
            var user = await _userRepository.GetByIdAsync(userId);

            if (user == null)
                return ResultService.Fail("Usuário não encontrado");

            await _userRepository.DeleteAsync(user);

            return ResultService.Ok($"Usuário com Id: {userId} foi excluído com sucesso!");
        }

        public async Task<ResultService<PagedBaseResponseDto<UserDto>>> GetPagedUserAsync(UserFilterDb userFilterDb)
        {
            var peoplePaged = await _userRepository.GetPagedUserAsync(userFilterDb);
            var result = new PagedBaseResponseDto<UserDto>(peoplePaged.TotalRegisters, _mapper.Map<List<UserDto>>(peoplePaged.Data));

            return ResultService.Ok(result);
        }
    }
}

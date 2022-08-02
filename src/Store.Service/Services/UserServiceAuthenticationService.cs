using Store.Domain.Authentication;
using Store.Domain.Repositories;
using Store.Service.DTOs;
using Store.Service.DTOs.Validations;
using Store.Service.Services.Interfaces;

namespace Store.Service.Services
{
    public class UserServiceAuthenticationService : IUserAuthenticationService
    {
        private readonly IUserAuthenticationRepository _userAuthenticationRepository;
        private readonly ITokenGenerator _tokenGenerator;

        public UserServiceAuthenticationService(IUserAuthenticationRepository userAuthenticationRepository, ITokenGenerator tokenGenerator)
        {
            _userAuthenticationRepository = userAuthenticationRepository;
            _tokenGenerator = tokenGenerator;
        }

        public async Task<ResultService<dynamic>> GenerateTokenAsync(UserAuthenticationDto userAuthenticationDto)
        {
            if (userAuthenticationDto == null)
                return ResultService.Fail<dynamic>("Objeto deve ser informado!");

            var validator = new UserAuthenticationDtoValidator().Validate(userAuthenticationDto);

            if (!validator.IsValid)
                return ResultService.RequestError<dynamic>("Problemas com a validação", validator);

            var user = await _userAuthenticationRepository.GetUserByEmailAndPassword(userAuthenticationDto.Email, userAuthenticationDto.Password);

            if (user == null)
                return ResultService.Fail<dynamic>("Usuário e senha não encontrado!");

            return ResultService.Ok(_tokenGenerator.GenerateToken(user));
        }
    }
}

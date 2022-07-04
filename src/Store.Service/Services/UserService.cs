﻿using AutoMapper;
using Store.Domain.Entities;
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

        public async Task<ResultService<UserDTO>> CreateAsync(UserDTO userDTO)
        {
            if (userDTO == null)
                return ResultService.Fail<UserDTO>("Deve ser informado o usuário!");

            var result = new UserDTOValidator().Validate(userDTO);

            if (!result.IsValid)
                return ResultService.RequestError<UserDTO>("Os campos estão incorretos!", result);

            var user = _mapper.Map<User>(userDTO);
            var data = await _userRepository.CreateUserAsync(user);
            return ResultService.Ok<UserDTO>(_mapper.Map<UserDTO>(data));
        }
    }
}

using FluentValidation;

namespace Store.Service.DTOs.Validations
{
    public class UserDtoValidator : AbstractValidator<UserDto>
    {
        public UserDtoValidator()
        {
            RuleFor(r => r.UserId)
                .NotEmpty()
                .NotNull()
                .WithMessage("Deve ser informando o ID!");
            RuleFor(r => r.LastName)
                .NotEmpty()
                .NotNull()
                .WithMessage("Deve ser informando o Sobrenome!");
            RuleFor(r => r.Name)
                .NotEmpty()
                .NotNull()
                .WithMessage("Deve ser informando o Nome!");
            RuleFor(r => r.Email)
                .NotEmpty()
                .NotNull()
                .WithMessage("Deve ser informando o Email!");
        }
    }
}

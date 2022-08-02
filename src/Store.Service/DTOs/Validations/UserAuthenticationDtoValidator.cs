using FluentValidation;

namespace Store.Service.DTOs.Validations
{
    public class UserAuthenticationDtoValidator : AbstractValidator<UserAuthenticationDto>
    {
        public UserAuthenticationDtoValidator()
        {
            RuleFor(x => x.Email)
                .NotEmpty()
                .NotNull()
                .WithMessage("Email deve ser informado!");
            RuleFor(x => x.Password)
                .NotEmpty()
                .NotNull()
                .WithMessage("Password deve ser informado!");
        }
    }
}

using FluentValidation;

namespace Store.Service.DTOs.Validations
{
    public class UserDTOValidator : AbstractValidator<UserDTO>
    {
        public UserDTOValidator()
        {
            RuleFor(r => r.Id)
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

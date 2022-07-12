using FluentValidation;

namespace Store.Service.DTOs.Validations
{
    public class PurchaseDTOValidator : AbstractValidator<PurchaseDTO>
    {
        public PurchaseDTOValidator()
        {
            RuleFor(r => r.Code)
                .NotEmpty()
                .NotNull()
                .WithMessage("Código do produto deve ser informado!");
            RuleFor(r => r.Document)
                .NotEmpty()
                .NotNull()
                .WithMessage("Código do produto deve ser informado!");
        }
    }
}

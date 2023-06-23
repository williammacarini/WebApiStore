using FluentValidation;

namespace Store.Service.DTOs.Validations
{
    public class ProductDtoValidator : AbstractValidator<ProductDto>
    {
        public ProductDtoValidator()
        {
            RuleFor(r => r.Name)
                .NotEmpty()
                .NotNull()
                .WithMessage("O nome deve ser preenchido!");
            RuleFor(r => r.Price)
                .NotEmpty()
                .NotNull()
                .GreaterThan(0)
                .WithMessage("O preço deve ser preenchido e maior que zero!");
            RuleFor(r => r.Code)
                .NotEmpty()
                .NotNull()
                .WithMessage("O código do produto deve ser informado!");
            RuleFor(r => r.ProductId)
                .NotEmpty()
                .NotNull()
                .WithMessage("O ID do produto deve ser informado!");
        }
    }
}

using FluentValidation;
using ProductsAndCategories.Business.DTOs.Product;

namespace ProductsAndCategories.Business.Validators.Product
{
    public class ProductUpdateDtoValidator : AbstractValidator<ProductUpdateDto>
    {
        public ProductUpdateDtoValidator()
        {
            RuleFor(p => p.Id)
                .NotNull();

            RuleFor(p => p.CategoryId)
                .NotNull();

            RuleFor(p => p.Price)
                .NotNull()
                .GreaterThan(0);

            RuleFor(p => p.Name)
                .NotEmpty()
                .NotNull()
                .MaximumLength(200);
        }
    }
}

using FluentValidation;
using ProductsAndCategories.Business.DTOs.Product;

namespace ProductsAndCategories.Business.Validators.Product
{
    public class ProductCreateDtoValidator : AbstractValidator<ProductCreateDto>
    {
        public ProductCreateDtoValidator()
        {
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

using FluentValidation;
using ProductsAndCategories.Business.DTOs.Category;

namespace ProductsAndCategories.Business.Validators.Category
{
    public class CategoryCreateDtoValidator : AbstractValidator<CategoryCreateDto>
    {
        public CategoryCreateDtoValidator()
        {
            RuleFor(c => c.Name)
                .NotEmpty()
                .NotNull()
                .MaximumLength(100);
        }
    }
}

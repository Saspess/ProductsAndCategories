using FluentValidation;
using ProductsAndCategories.Business.DTOs.Category;

namespace ProductsAndCategories.Business.Validators.Category
{
    public class CategoryUpdateDtoValidator : AbstractValidator<CategoryUpdateDto>
    {
        public CategoryUpdateDtoValidator()
        {
            RuleFor(c => c.Id)
                .NotNull();

            RuleFor(c => c.Name)
                .NotEmpty()
                .NotNull()
                .MaximumLength(100);
        }
    }
}

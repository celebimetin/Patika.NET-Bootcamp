using FluentValidation;

namespace Schema.Validations
{
    public class CategoryRequestValidator : AbstractValidator<CategoryRequest>
    {
        public CategoryRequestValidator()
        {
            RuleFor(x => x.Name).NotNull().NotEmpty();
            RuleFor(x => x.Picture).NotNull().NotEmpty();
        }
    }
}
using FluentValidation;

namespace Schema.Validations.Basket
{
    public class BasketDtoValidator : AbstractValidator<BasketDto>
    {
        public BasketDtoValidator()
        {
            RuleFor(x => x.UserId).NotNull().NotEmpty();
            RuleFor(x => x.DiscountCode).MinimumLength(10);
        }
    }
}
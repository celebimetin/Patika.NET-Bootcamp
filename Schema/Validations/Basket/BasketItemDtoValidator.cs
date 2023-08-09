using FluentValidation;

namespace Schema.Validations.Basket
{
    public class BasketItemDtoValidator : AbstractValidator<BasketItemDto>
    {
        public BasketItemDtoValidator()
        {
            RuleFor(x => x.Quantity).NotNull().NotEmpty();
            RuleFor(x => x.Price).NotNull().NotEmpty();
            RuleFor(x => x.ProductId).NotNull().NotEmpty();
            RuleFor(x => x.BasketId).NotNull().NotEmpty();
            RuleFor(x => x.ProductName).NotNull().NotEmpty();
        }
    }
}
using FluentValidation;

namespace Schema.Validations.Order
{
    public class OrderItemDtoValidator : AbstractValidator<OrderItemDto>
    {
        public OrderItemDtoValidator()
        {
            RuleFor(x => x.ProductId).NotNull().NotEmpty();
            RuleFor(x => x.ProductName).NotNull().NotEmpty().Length(3, 100);
            RuleFor(x => x.Price).NotNull().NotEmpty();
        }
    }
}
using FluentValidation;

namespace Schema.Validations.Order
{
    public class AddressDtoValidator : AbstractValidator<AddressDto>
    {
        public AddressDtoValidator()
        {
            RuleFor(x => x.Province).NotNull().NotEmpty().Length(3, 100);
            RuleFor(x => x.District).NotNull().NotEmpty().Length(3, 100);
            RuleFor(x => x.Street).NotNull().NotEmpty().Length(3, 100);
            RuleFor(x => x.ZipCode).NotNull().NotEmpty().Length(3, 10);
            RuleFor(x => x.Line).NotNull().NotEmpty().Length(3, 100);
        }
    }
}
using FluentValidation;

namespace Schema.Validations
{
    public class KuponRequestValidator : AbstractValidator<KuponRequest>
    {
        public KuponRequestValidator()
        {
            RuleFor(x => x.Name).NotNull().NotEmpty().Length(3, 25);
            RuleFor(x => x.UserId).NotNull().NotEmpty();
            RuleFor(x => x.Rate).NotNull().NotEmpty();
            RuleFor(x => x.Status).NotNull().NotEmpty();
        }
    }
}
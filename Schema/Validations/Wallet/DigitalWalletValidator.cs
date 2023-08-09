using Data.Domain;
using FluentValidation;

namespace Schema.Validations.Wallet
{
    public class DigitalWalletValidator : AbstractValidator<DigitalWallet>
    {
        public DigitalWalletValidator()
        {
            RuleFor(x => x.UserId).NotNull().NotEmpty();
            RuleFor(x => x.Balance).NotNull().NotEmpty();
        }
    }
}
using Domain.Models;
using FluentValidation;

namespace FinanceManagement.Validator
{
    public class AccountValidator : AbstractValidator<Account>
    {
        public AccountValidator()
        {
            RuleFor(account => account.AccountNumber)
                .NotEmpty().WithMessage("Account number is required.")
                .MaximumLength(20).WithMessage("Account number must not exceed 50 characters.");

            RuleFor(account => account.Balance)
                .NotNull().WithMessage("Balance is required.")
                .GreaterThanOrEqualTo(0).WithMessage("Balance cannot be negative.");

            RuleFor(account => account.AccountTypeId)
                .NotNull().WithMessage("Account type is required.")
                .GreaterThan(0).WithMessage("Invalid account type.");

            RuleFor(account => account.UserId)
                .NotNull().WithMessage("User ID is required.")
                .GreaterThan(0).WithMessage("Invalid user ID.");
        }
    }
}

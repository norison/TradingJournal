using FluentValidation;

namespace TradingJournal.Application.Features.Accounts.Commands.UpdateAccount;

public class UpdateAccountCommandValidator : AbstractValidator<UpdateAccountCommand>
{
    public UpdateAccountCommandValidator()
    {
        RuleFor(x => x.Id)
            .GreaterThan(0).WithMessage("Id must be greater than 0.");
        
        RuleFor(x => x.Name)
            .NotEmpty().WithMessage("Name is required.")
            .MaximumLength(50).WithMessage("Name must not exceed 50 characters.");

        RuleFor(x => x.RiskBalance)
            .GreaterThan(0).WithMessage("Risk balance must be greater than 0.");

        RuleFor(x => x.Type)
            .IsInEnum().WithMessage("Account type is not valid.");

        RuleFor(x => x.Description)
            .MaximumLength(500).WithMessage("Description must not exceed 500 characters.");

        RuleFor(x => x.Split)
            .GreaterThan(0).WithMessage("Split must be greater than 0.");
    }
}
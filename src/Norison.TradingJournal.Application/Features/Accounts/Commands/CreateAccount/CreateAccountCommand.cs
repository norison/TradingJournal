using Mediator;
using Norison.TradingJournal.Application.Models.Enums;

namespace Norison.TradingJournal.Application.Features.Accounts.Commands.CreateAccount;

public class CreateAccountCommand : ICommand<long>
{
    public string Name { get; set; } = string.Empty;
    public decimal RiskBalance { get; set; }
    public AccountType Type { get; set; }
    public string? Description { get; set; }
    public decimal? Split { get; set; }
}
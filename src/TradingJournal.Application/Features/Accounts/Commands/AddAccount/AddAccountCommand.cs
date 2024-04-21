using Mediator;
using TradingJournal.Application.Models.Enums;

namespace TradingJournal.Application.Features.Accounts.Commands.AddAccount;

public class AddAccountCommand : ICommand<int>
{
    public string Name { get; set; } = string.Empty;
    public decimal RiskBalance { get; set; }
    public AccountType Type { get; set; }
    public string? Description { get; set; }
    public decimal? Split { get; set; }
}
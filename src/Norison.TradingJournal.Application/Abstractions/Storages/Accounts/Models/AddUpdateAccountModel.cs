using Norison.TradingJournal.Application.Models.Enums;

namespace Norison.TradingJournal.Application.Abstractions.Storages.Accounts.Models;

public class AddUpdateAccountModel
{
    public string Name { get; set; } = string.Empty;
    public decimal RiskBalance { get; set; }
    public AccountType Type { get; set; }
    public string? Description { get; set; }
    public decimal? Split { get; set; }
}
using Norison.TradingJournal.Application.Models.Enums;

namespace Norison.TradingJournal.SqlitePersistence.Entities;

public class AccountEntity
{
    public long Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public decimal RiskBalance { get; set; }
    public AccountType Type { get; set; }
    public string? Description { get; set; }
    public decimal? Split { get; set; }
}
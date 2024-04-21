using TradingJournal.Application.Models.Enums;

namespace TradingJournal.Application.Models;

public class Account
{
    public int Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public decimal RiskBalance { get; set; }
    public AccountType Type { get; set; }
    public string? Description { get; set; }
    public decimal? Split { get; set; }
}
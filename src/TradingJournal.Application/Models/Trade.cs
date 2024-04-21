using TradingJournal.Application.Models.Enums;

namespace TradingJournal.Application.Models;

public class Trade
{
    public int Id { get; set; }
    public DateTime OpenDateTime { get; set; }
    public DateTime? CloseDateTime { get; set; }
    public Account Account { get; set; } = new();
    public Instrument Instrument { get; set; } = new();
    public Setup Setup { get; set; } = new();
    public TradeStatus Status { get; set; }
    public Session Session { get; set; }
    public Direction Direction { get; set; }
    public Position Position { get; set; }
    public string Notes { get; set; } = string.Empty;
    public decimal RiskPercent { get; set; }
    public decimal EntryPrice { get; set; }
    public decimal? ExitPrice { get; set; }
    public decimal? StopLoss { get; set; }
    public decimal? TakeProfit { get; set; }
}
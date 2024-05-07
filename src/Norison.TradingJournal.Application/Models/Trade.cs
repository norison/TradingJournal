using Norison.TradingJournal.Application.Models.Enums;

namespace Norison.TradingJournal.Application.Models;

public class Trade
{
    public long Id { get; set; }
    public DateTime EntryDateTime { get; set; }
    public DateTime? ExitDateTime { get; set; }
    public Account Account { get; set; } = new();
    public Instrument Instrument { get; set; } = new();
    public Setup Setup { get; set; } = new();
    public TradeStatus Status { get; set; }
    public Direction Direction { get; set; }
    public Position Position { get; set; }
    public Session EntrySession { get; set; }
    public Session? ExitSession { get; set; }
    public string? Notes { get; set; }
    public decimal RiskPercent { get; set; }
    public decimal EntryPrice { get; set; }
    public decimal? ExitPrice { get; set; }
    public decimal StopLoss { get; set; }
    public decimal? TakeProfit { get; set; }
    public IEnumerable<Image> Images { get; set; } = Enumerable.Empty<Image>();
}
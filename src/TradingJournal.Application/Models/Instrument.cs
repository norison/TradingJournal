using TradingJournal.Application.Models.Enums;

namespace TradingJournal.Application.Models;

public class Instrument
{
    public int Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public Market Market { get; set; }
}
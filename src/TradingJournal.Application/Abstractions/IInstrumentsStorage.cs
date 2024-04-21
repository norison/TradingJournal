using System.Diagnostics.Metrics;

namespace TradingJournal.Application.Abstractions;

public interface IInstrumentsStorage
{
    Task AddInstrumentAsync(Instrument instrument);
    Task<IEnumerable<Instrument>> GetInstrumentsAsync();
    Task<Instrument> GetInstrumentAsync(int id);
    Task UpdateInstrumentAsync(Instrument instrument);
    Task DeleteInstrumentAsync(int id);
}
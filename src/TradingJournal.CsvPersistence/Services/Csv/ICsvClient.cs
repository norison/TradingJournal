namespace TradingJournal.CsvPersistence.Services.Csv;

public interface ICsvClient
{
    Task WriteRecordsAsync<T>(IEnumerable<T> records, CancellationToken cancellationToken = default) where T : class;
    Task<IEnumerable<T>> ReadRecordsAsync<T>(CancellationToken cancellationToken = default) where T : class;
}
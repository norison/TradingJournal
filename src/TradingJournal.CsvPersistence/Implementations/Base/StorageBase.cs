using TradingJournal.CsvPersistence.Services.Csv;

namespace TradingJournal.CsvPersistence.Implementations.Base;

public abstract class StorageBase<T>(ICsvClient csvClient) where T : class
{
    private readonly List<T> _records = [];
    private readonly SemaphoreSlim _semaphore = new(1, 1);
    
    protected async Task WriteRecordsAsync(IEnumerable<T> records, CancellationToken cancellationToken = default)
    {
        try
        {
            await _semaphore.WaitAsync(cancellationToken);
            
            _records.Clear();
            _records.AddRange(records);
            await csvClient.WriteRecordsAsync(_records, cancellationToken);
        }
        finally
        {
            _semaphore.Release();
        }
    }
    
    protected async Task<IEnumerable<T>> ReadRecordsAsync(CancellationToken cancellationToken = default)
    {
        try
        {
            await _semaphore.WaitAsync(cancellationToken);
            
            if (_records.Count > 0)
            {
                return _records;
            }
        
            var records = await csvClient.ReadRecordsAsync<T>(cancellationToken);
            _records.AddRange(records);
            return _records;
        }
        finally
        {
            _semaphore.Release();
        }
    }
}
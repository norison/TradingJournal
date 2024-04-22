using System.Diagnostics.CodeAnalysis;
using System.Globalization;
using CsvHelper;
using CsvHelper.Configuration;

namespace TradingJournal.CsvPersistence.Services.Csv;

[ExcludeFromCodeCoverage]
public class CsvClient : ICsvClient
{
    private readonly CsvConfiguration _csvConfiguration = new(CultureInfo.InvariantCulture)
    {
        HasHeaderRecord = true,
        Delimiter = ","
    };

    public async Task WriteRecordsAsync<T>(IEnumerable<T> records, CancellationToken cancellationToken = default)
        where T : class
    {
        await using var writer = new StreamWriter($"{typeof(T).Name}.csv");
        await using var csv = new CsvWriter(writer, _csvConfiguration);
        await csv.WriteRecordsAsync(records, cancellationToken);
    }

    public async Task<IEnumerable<T>> ReadRecordsAsync<T>(CancellationToken cancellationToken = default) where T : class
    {
        using var reader = new StreamReader($"{typeof(T).Name}.csv");
        using var csv = new CsvReader(reader, _csvConfiguration);

        var records = new List<T>();

        await foreach (var record in csv.GetRecordsAsync<T>(cancellationToken))
        {
            records.Add(record);
        }

        return records;
    }
}
using TradingJournal.Application.Abstractions.Storages.Accounts;
using TradingJournal.Application.Abstractions.Storages.Accounts.Models;
using TradingJournal.Application.Models;
using TradingJournal.CsvPersistence.Implementations.Base;
using TradingJournal.CsvPersistence.Services.Csv;

namespace TradingJournal.CsvPersistence.Implementations.Accounts;

public class CsvAccountsStorage(ICsvClient csvClient) : StorageBase<Account>(csvClient), IAccountsStorage
{
    public async Task<long> AddAccountAsync(AddUpdateAccountModel model, CancellationToken cancellationToken = default)
    {
        var accounts = await ReadRecordsAsync(cancellationToken);
        var accountsList = accounts.ToList();
        var id = accountsList.Count > 0 ? accountsList.Max(x => x.Id) + 1 : 1;
        var newAccount = model.ToAccount();
        newAccount.Id = id;
        accountsList.Add(newAccount);
        await WriteRecordsAsync(accountsList, cancellationToken);
        return id;
    }

    public async Task<IEnumerable<Account>> GetAccountsAsync(CancellationToken cancellationToken = default)
    {
        return await ReadRecordsAsync(cancellationToken);
    }

    public async Task<Account?> GetAccountByIdAsync(long id, CancellationToken cancellationToken = default)
    {
        var accounts = await ReadRecordsAsync(cancellationToken);
        return accounts.FirstOrDefault(x => x.Id == id);
    }

    public async Task UpdateAccountAsync(long id, AddUpdateAccountModel model, CancellationToken cancellationToken = default)
    {
        var accounts = await ReadRecordsAsync(cancellationToken);
        var accountsList = accounts.ToList();
        var account = accountsList.First(x => x.Id == id);
        
        account.Name = model.Name;
        account.RiskBalance = model.RiskBalance;
        account.Type = model.Type;
        account.Description = model.Description;
        account.Split = model.Split;
        
        await WriteRecordsAsync(accountsList, cancellationToken);
    }

    public async Task DeleteAccountAsync(long id, CancellationToken cancellationToken = default)
    {
        var accounts = await ReadRecordsAsync(cancellationToken);
        var accountsList = accounts.ToList();
        accountsList.RemoveAll(x => x.Id == id);
        await WriteRecordsAsync(accountsList, cancellationToken);
    }
}
using Microsoft.EntityFrameworkCore;
using Norison.TradingJournal.Application.Abstractions.Storages.Accounts;
using Norison.TradingJournal.Application.Abstractions.Storages.Accounts.Models;
using Norison.TradingJournal.Application.Models;

namespace Norison.TradingJournal.SqlitePersistence.Implementations;

public class AccountsStorage(IDbContextFactory<TradingJournalDbContext> dbContextFactory) : IAccountsStorage
{
    public Task<long> AddAccountAsync(AddUpdateAccountModel model, CancellationToken cancellationToken = default)
    {
        throw new NotImplementedException();
    }

    public Task<IEnumerable<Account>> GetAccountsAsync(CancellationToken cancellationToken = default)
    {
        throw new NotImplementedException();
    }

    public Task<Account?> GetAccountByIdAsync(long id, CancellationToken cancellationToken = default)
    {
        throw new NotImplementedException();
    }

    public Task UpdateAccountAsync(long id, AddUpdateAccountModel model, CancellationToken cancellationToken = default)
    {
        throw new NotImplementedException();
    }

    public Task DeleteAccountAsync(long id, CancellationToken cancellationToken = default)
    {
        throw new NotImplementedException();
    }
}
using TradingJournal.Application.Abstractions.Storages.Accounts.Models.AddAccount;

namespace TradingJournal.Application.Abstractions.Storages.Accounts;

public interface IAccountsStorage
{
    Task<long> AddAccountAsync(AddAccountModel model, CancellationToken cancellationToken = default);
}
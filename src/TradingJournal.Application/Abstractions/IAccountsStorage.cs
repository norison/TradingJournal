using TradingJournal.Application.Abstractions.Storages.Accounts.Models.AddAccount;

namespace TradingJournal.Application.Abstractions;

public interface IAccountsStorage
{
    Task<int> AddAccountAsync(AddAccountModel model, CancellationToken cancellationToken = default);
}
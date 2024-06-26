﻿using Norison.TradingJournal.Application.Abstractions.Storages.Accounts.Models;
using Norison.TradingJournal.Application.Models;

namespace Norison.TradingJournal.Application.Abstractions.Storages.Accounts;

public interface IAccountsStorage
{
    Task<long> AddAccountAsync(AddUpdateAccountModel model, CancellationToken cancellationToken = default);
    Task<IEnumerable<Account>> GetAccountsAsync(CancellationToken cancellationToken = default);
    Task<Account?> GetAccountByIdAsync(long id, CancellationToken cancellationToken = default);
    Task UpdateAccountAsync(long id, AddUpdateAccountModel model, CancellationToken cancellationToken = default);
    Task DeleteAccountAsync(long id, CancellationToken cancellationToken = default);
}
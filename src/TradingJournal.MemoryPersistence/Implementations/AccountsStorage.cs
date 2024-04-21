using TradingJournal.Application.Abstractions;
using TradingJournal.Application.Abstractions.Storages.Accounts.Models.AddAccount;
using TradingJournal.Application.Models;

namespace TradingJournal.MemoryPersistence.Implementations;

public class AccountsStorage : IAccountsStorage
{
    private readonly IDictionary<int, Account> _accounts = new Dictionary<int, Account>();
    
    public Task<int> AddAccountAsync(AddAccountModel model, CancellationToken cancellationToken = default)
    {
        var id = _accounts.Count + 1;
        
        var account = new Account
        {
            Id = id,
            Name = model.Name,
            RiskBalance = model.RiskBalance,
            Type = model.Type,
            Description = model.Description,
            Split = model.Split,
        };
        
        _accounts.Add(id, account);
        
        return Task.FromResult(id);
    }
}
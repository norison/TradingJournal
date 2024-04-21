using TradingJournal.Application.Models;

namespace TradingJournal.Application.Abstractions;

public interface IAccountsStorage
{
    Task AddAccountAsync(Account account);
    Task<IEnumerable<Account>> GetAccountsAsync();
    Task<Account> GetAccountAsync(int id);
    Task UpdateAccountAsync(Account account);
    Task DeleteAccountAsync(int id);
}
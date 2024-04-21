using TradingJournal.Application.Models;

namespace TradingJournal.Application.Abstractions;

public interface ISetupsStorage
{
    Task AddSetupAsync(Setup setup);
    Task<IEnumerable<Setup>> GetSetupsAsync();
    Task<Setup> GetSetupAsync(int id);
    Task UpdateSetupAsync(Setup setup);
    Task DeleteSetupAsync(int id);
}
using System.Diagnostics.CodeAnalysis;
using Microsoft.Extensions.DependencyInjection;
using Norison.TradingJournal.Application.Abstractions.Storages.Accounts;
using Norison.TradingJournal.SqlitePersistence.Implementations;

namespace Norison.TradingJournal.SqlitePersistence.Extensions;

[ExcludeFromCodeCoverage]
public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddSqlitePersistence(this IServiceCollection services)
    {
        services.AddDbContextFactory<TradingJournalDbContext>();
        services.AddSingleton<IAccountsStorage, AccountsStorage>();

        return services;
    }
}
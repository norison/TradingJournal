using Riok.Mapperly.Abstractions;
using TradingJournal.Application.Abstractions.Storages.Accounts.Models;
using TradingJournal.Application.Models;

namespace TradingJournal.CsvPersistence.Implementations.Accounts;

[Mapper]
public static partial class CsvAccountsStorageMapper
{
    public static partial Account ToAccount(this AddUpdateAccountModel model);
}
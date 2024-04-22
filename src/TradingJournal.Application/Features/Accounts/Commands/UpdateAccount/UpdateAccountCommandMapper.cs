using Riok.Mapperly.Abstractions;
using TradingJournal.Application.Abstractions.Storages.Accounts.Models;

namespace TradingJournal.Application.Features.Accounts.Commands.UpdateAccount;

[Mapper]
public static partial class UpdateAccountCommandMapper
{
    public static partial AddUpdateAccountModel ToAddUpdateAccountModel(this UpdateAccountCommand command);
}
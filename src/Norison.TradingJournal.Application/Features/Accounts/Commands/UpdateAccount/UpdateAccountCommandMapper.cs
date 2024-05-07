using Norison.TradingJournal.Application.Abstractions.Storages.Accounts.Models;
using Riok.Mapperly.Abstractions;

namespace Norison.TradingJournal.Application.Features.Accounts.Commands.UpdateAccount;

[Mapper]
public static partial class UpdateAccountCommandMapper
{
    public static partial AddUpdateAccountModel ToAddUpdateAccountModel(this UpdateAccountCommand command);
}
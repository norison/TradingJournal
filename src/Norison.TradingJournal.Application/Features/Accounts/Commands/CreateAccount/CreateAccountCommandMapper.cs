using Norison.TradingJournal.Application.Abstractions.Storages.Accounts.Models;
using Riok.Mapperly.Abstractions;

namespace Norison.TradingJournal.Application.Features.Accounts.Commands.CreateAccount;

[Mapper]
public static partial class CreateAccountCommandMapper
{
    public static partial AddUpdateAccountModel ToAddUpdateAccountModel(this CreateAccountCommand command);
}
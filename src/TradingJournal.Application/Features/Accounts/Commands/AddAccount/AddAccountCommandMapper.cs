using Riok.Mapperly.Abstractions;
using TradingJournal.Application.Abstractions.Storages.Accounts.Models;

namespace TradingJournal.Application.Features.Accounts.Commands.AddAccount;

[Mapper]
public static partial class AddAccountCommandMapper
{
    public static partial AddUpdateAccountModel ToAddUpdateAccountModel(this AddAccountCommand command);
}
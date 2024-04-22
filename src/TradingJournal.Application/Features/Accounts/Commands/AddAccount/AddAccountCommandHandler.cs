using Mediator;
using TradingJournal.Application.Abstractions.Storages.Accounts;
using TradingJournal.Application.Abstractions.Storages.Accounts.Models;

namespace TradingJournal.Application.Features.Accounts.Commands.AddAccount;

public class AddAccountCommandHandler(IAccountsStorage accountsStorage) : ICommandHandler<AddAccountCommand, long>
{
    public async ValueTask<long> Handle(AddAccountCommand command, CancellationToken cancellationToken)
    {
        var addAccountModel = command.ToAddUpdateAccountModel();
        return await accountsStorage.AddAccountAsync(addAccountModel, cancellationToken);
    }
}
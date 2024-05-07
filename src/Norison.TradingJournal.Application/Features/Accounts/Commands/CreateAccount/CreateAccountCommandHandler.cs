using Mediator;
using Norison.TradingJournal.Application.Abstractions.Storages.Accounts;

namespace Norison.TradingJournal.Application.Features.Accounts.Commands.CreateAccount;

public class CreateAccountCommandHandler(IAccountsStorage accountsStorage) : ICommandHandler<CreateAccountCommand, long>
{
    public async ValueTask<long> Handle(CreateAccountCommand command, CancellationToken cancellationToken)
    {
        var addAccountModel = command.ToAddUpdateAccountModel();
        return await accountsStorage.AddAccountAsync(addAccountModel, cancellationToken);
    }
}
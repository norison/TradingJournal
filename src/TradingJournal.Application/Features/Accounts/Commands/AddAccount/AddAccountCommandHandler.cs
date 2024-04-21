using Mediator;
using TradingJournal.Application.Abstractions;
using TradingJournal.Application.Abstractions.Storages.Accounts.Models.AddAccount;

namespace TradingJournal.Application.Features.Accounts.Commands.AddAccount;

public class AddAccountCommandHandler(IAccountsStorage accountsStorage) : ICommandHandler<AddAccountCommand, int>
{
    public async ValueTask<int> Handle(AddAccountCommand command, CancellationToken cancellationToken)
    {
        var addAccountModel = new AddAccountModel
        {
            Name = command.Name,
            RiskBalance = command.RiskBalance,
            Type = command.Type,
            Description = command.Description,
            Split = command.Split
        };

        return await accountsStorage.AddAccountAsync(addAccountModel, cancellationToken);
    }
}
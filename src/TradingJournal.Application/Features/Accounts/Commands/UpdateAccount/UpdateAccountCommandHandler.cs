﻿using Mediator;
using TradingJournal.Application.Abstractions.Storages.Accounts;
using TradingJournal.Application.Exceptions.Accounts;

namespace TradingJournal.Application.Features.Accounts.Commands.UpdateAccount;

public class UpdateAccountCommandHandler(IAccountsStorage accountsStorage) : ICommandHandler<UpdateAccountCommand>
{
    public async ValueTask<Unit> Handle(UpdateAccountCommand command, CancellationToken cancellationToken)
    {
        var account = await accountsStorage.GetAccountByIdAsync(command.Id, cancellationToken);
        
        if (account is null)
        {
            throw new AccountNotFoundException(command.Id);
        }
        
        var updateAccountModel = command.ToAddUpdateAccountModel();

        await accountsStorage.UpdateAccountAsync(command.Id, updateAccountModel, cancellationToken);

        return Unit.Value;
    }
}
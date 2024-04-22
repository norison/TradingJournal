﻿using Mediator;
using TradingJournal.Application.Abstractions.Storages.Accounts;
using TradingJournal.Application.Exceptions.Accounts;

namespace TradingJournal.Application.Features.Accounts.Commands.DeleteAccount;

public class DeleteAccountCommandHandler(IAccountsStorage accountsStorage) : ICommandHandler<DeleteAccountCommand>
{
    public async ValueTask<Unit> Handle(DeleteAccountCommand command, CancellationToken cancellationToken)
    {
        var account = await accountsStorage.GetAccountByIdAsync(command.Id, cancellationToken);
        
        if (account is null)
        {
            throw new AccountNotFoundException(command.Id);
        }
        
        await accountsStorage.DeleteAccountAsync(command.Id, cancellationToken);
        
        return Unit.Value;
    }
}
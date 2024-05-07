using Mediator;

namespace Norison.TradingJournal.Application.Features.Accounts.Commands.DeleteAccount;

public class DeleteAccountCommand : ICommand
{
    public long Id { get; set; }
}
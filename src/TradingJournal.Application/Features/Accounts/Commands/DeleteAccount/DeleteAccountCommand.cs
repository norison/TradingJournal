using Mediator;

namespace TradingJournal.Application.Features.Accounts.Commands.DeleteAccount;

public class DeleteAccountCommand : ICommand
{
    public long Id { get; set; }
}
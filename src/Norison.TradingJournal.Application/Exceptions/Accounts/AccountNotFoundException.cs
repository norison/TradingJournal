using Norison.TradingJournal.Application.Exceptions.Base;

namespace Norison.TradingJournal.Application.Exceptions.Accounts;

public class AccountNotFoundException(long id) : NotFoundException($"Account with id {id} not found.");
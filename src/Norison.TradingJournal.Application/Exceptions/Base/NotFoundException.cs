namespace Norison.TradingJournal.Application.Exceptions.Base;

public abstract class NotFoundException(string message) : TradingJournalException(message);
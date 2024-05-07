namespace Norison.TradingJournal.Application.Exceptions.Base;

public abstract class ValidationException(string message) : TradingJournalException(message);
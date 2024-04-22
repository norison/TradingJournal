using TradingJournal.Application.Exceptions.Base;

namespace TradingJournal.Application.Exceptions;

public class ModelValidationException(string message) : ValidationException(message);
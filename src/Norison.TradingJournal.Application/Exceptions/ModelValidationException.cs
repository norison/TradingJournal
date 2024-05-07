using Norison.TradingJournal.Application.Exceptions.Base;

namespace Norison.TradingJournal.Application.Exceptions;

public class ModelValidationException(string message) : ValidationException(message);
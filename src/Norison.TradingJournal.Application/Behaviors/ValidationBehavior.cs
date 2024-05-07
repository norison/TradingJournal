using FluentValidation;
using Mediator;
using Norison.TradingJournal.Application.Exceptions;

namespace Norison.TradingJournal.Application.Behaviors;

public sealed class ValidationBehavior<TMessage, TResponse>(IEnumerable<IValidator<TMessage>> validators)
    : IPipelineBehavior<TMessage, TResponse> where TMessage : IMessage
{
    public async ValueTask<TResponse> Handle(
        TMessage message,
        CancellationToken cancellationToken,
        MessageHandlerDelegate<TMessage, TResponse> next)
    {
        if (!validators.Any())
        {
            return await next(message, cancellationToken);
        }

        var context = new ValidationContext<TMessage>(message);

        var validationTasks = validators
            .Select(x => x.ValidateAsync(context, cancellationToken));

        var validationResults = await Task.WhenAll(validationTasks);

        var validationFailures = validationResults
            .SelectMany(x => x.Errors)
            .Where(x => x != null)
            .ToList();

        if (validationFailures.Count == 0)
        {
            return await next(message, cancellationToken);
        }

        var firstError = validationFailures.First().ErrorMessage;
        
        throw new ModelValidationException(firstError);
    }
}
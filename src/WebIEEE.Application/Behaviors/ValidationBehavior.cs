using FluentValidation;
using MediatR;
using Microsoft.Extensions.Logging;
using WebIEEE.Contracts.Errors;
using WebIEEE.Contracts.Exceptions;

namespace WebIEEE.Application.Behaviors;

public class ValidationBehavior<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse>
{
    private readonly IEnumerable<IValidator<TRequest>> _validators;

    public ValidationBehavior(IEnumerable<IValidator<TRequest>> validators)
    {
        _validators = validators;
    }
    
    public async Task<TResponse> Handle(TRequest request, RequestHandlerDelegate<TResponse> next,
        CancellationToken cancellationToken)
    {
        var context = new ValidationContext<TRequest>(request);
        
        var validationResults = 
            await Task.WhenAll(_validators.Select(x => x.ValidateAsync(context, cancellationToken)));
        
        var failures = validationResults
            .Where(x => !x.IsValid)
            .SelectMany(x => x.Errors)
            .Select(x => new ValidationError
            {
                PropertyName = x.PropertyName,
                ErrorMessage = x.ErrorMessage,
            }).ToList();

        if (failures.Count != 0)
        {
            throw new CustomValidationException(failures);
        }
        
        var response = await next();
        return response;
    }
}
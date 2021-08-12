using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using FluentValidation;
using MediatR;

namespace Application.Common.Behaviours
{
    public class ValidationBehaviour<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse>
        where TRequest : IRequest<TResponse>
    {
        private readonly IEnumerable<IValidator<TRequest>> _validators;

        public ValidationBehaviour(IEnumerable<IValidator<TRequest>> validators)
        {
            _validators = validators;
        }

        public async Task<TResponse> Handle(TRequest request, CancellationToken cancellationToken,
            RequestHandlerDelegate<TResponse> next)
        {
            if (_validators.Any())
            {
                var validationContext = new ValidationContext<TRequest>(request);

                var validationResults = await Task.WhenAll(
                    _validators.Select(validator => validator.ValidateAsync(validationContext, cancellationToken))
                );
                var failures = validationResults
                    .SelectMany(validationResult => validationResult.Errors)
                    .Where(validationFailure => validationFailure != null)
                    .ToList();

                if (failures.Any())
                {
                    throw new Application.Common.Exceptions.ValidationException(failures);
                }
            }

            return await next();
        }
    }
}
using FluentValidation;
using FluentValidation.Results;
using MediatR;
using System.Linq;

namespace MovieCollection.API.Commands.Behavior
{
    public class ValidationBehavior<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse> where TRequest : class
    {
        private readonly IEnumerable<IValidator<TRequest>> _validators;

        public ValidationBehavior(IEnumerable<IValidator<TRequest>> validators) 
        { 
            _validators = validators; 
        }
        public async Task<TResponse> Handle(TRequest request, RequestHandlerDelegate<TResponse> next, CancellationToken cancellationToken)
        {
            if (!_validators.Any())
            {
                return await next();
            }
            var context = new ValidationContext<TRequest>(request);
            var errorsList = _validators
                .Select(x => x.Validate(context))
                .SelectMany(x => x.Errors)
                .Where(x => x != null)
                .GroupBy(
                    x => x.PropertyName,
                    x => x.ErrorMessage,
                    (propertyName, errorMessages) => new ValidationFailure
                    {
                        ErrorCode = "5001",
                        PropertyName = propertyName,
                        ErrorMessage = string.Join("\r\n",errorMessages)
                    })
                .ToList<ValidationFailure>();
            if (errorsList.Any())
            {
                throw new ValidationException(errorsList);
            }
            return await next();
        }
    }
}

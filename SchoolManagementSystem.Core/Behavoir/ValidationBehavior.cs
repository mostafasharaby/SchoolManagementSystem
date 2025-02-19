using FluentValidation;
using MediatR;
using SchoolManagementSystem.Core.Bases;

namespace SchoolManagementSystem.Core.Behavoir
{
    public class ValidationBehavior<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse>
        where TRequest : IRequest<TResponse>
    {
        private readonly IEnumerable<IValidator<TRequest>> _validators;

        public ValidationBehavior(IEnumerable<IValidator<TRequest>> validators)
        {
            _validators = validators;
        }

        public async Task<TResponse> Handle(TRequest request, RequestHandlerDelegate<TResponse> next, CancellationToken cancellationToken)
        {
            if (_validators.Any())  // if behavoir run the fluentValidator and find errors so it will prevent the command to reach the handler
            {
                var context = new ValidationContext<TRequest>(request);
                var validationResults = await Task.WhenAll(_validators.Select(v => v.ValidateAsync(context, cancellationToken)));
                var failures = validationResults.SelectMany(r => r.Errors).Where(f => f != null).ToList();

                if (failures.Count != 0)
                {
                    var responseType = typeof(TResponse);
                    if (responseType.IsGenericType && responseType.GetGenericTypeDefinition() == typeof(Response<>))
                    {
                        var responseInstance = (TResponse)Activator.CreateInstance(responseType);
                        var responseProperty = responseType.GetProperty("Errors");
                        responseProperty?.SetValue(responseInstance, failures.Select(e => e.ErrorMessage).ToList());
                        return responseInstance;
                    }

                    throw new ValidationException(failures);
                }
            }

            return await next(); // ok this validation is alright the got to handler 
        }
    }
}

/*
  How They Work Together?
✔️ FluentValidation defines validation rules.
✔️ Behavior (Validation Pipeline) automates running the validation before the command reaches the handler.
✔️ If validation fails, the behavior prevents execution of the handler and returns errors.

 
  How This Works in Your Case?
✔️ When CreateStudentWithResponse is called, MediatR sends AddStudentCommandWithResponse.
✔️ Before the request reaches the handler, --->ValidationBehavior runs FluentValidation<---.
✔️ If validation fails, it stops execution and returns an error response.
✔️ If validation passes, the request proceeds to the handler.  
 */
using FluentValidation;
using InnoTree.Core.Exceptions;
using MediatR;
using System.Text;

namespace InnoTree.Application.MediatR.PipelineBehaviors;

public class ValidationBehavior<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse>
{
	private readonly IEnumerable<IValidator<TRequest>> _validators;

	public ValidationBehavior(IEnumerable<IValidator<TRequest>> validators)
	{
		_validators = validators;
	}

	public async Task<TResponse> Handle(
		TRequest request, 
		RequestHandlerDelegate<TResponse> next, 
		CancellationToken cancellationToken)
	{
		var context = new ValidationContext<TRequest>(request);

		var validationFailures = await Task.WhenAll(
			_validators.Select(validator => validator.ValidateAsync(context)));

		var errors = validationFailures
			.Where(validationResult => !validationResult.IsValid)
			.SelectMany(validationResult => validationResult.Errors)
			.Select(validationFailure => new ValidationException(validationFailure.ErrorMessage))
			.ToList();

		if (errors.Any())
		{
			StringBuilder message = new StringBuilder();

			errors.ForEach(e => message.AppendLine(e.Message));

			throw new BadRequestException($"{message.ToString()}");
		}

		var response = await next();

		return response;
	}
}

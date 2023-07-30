using Expect.Bookmuse.Domain;
using FluentValidation;
using MediatR;

namespace Expect.Bookmuse.Infrastructure.Common.Behavior
{
	public class ValidationBehavior<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse> where TRequest : IRequest<TResponse>
	{
		private readonly IEnumerable<IValidator<TRequest>> _validators;

		public ValidationBehavior(IEnumerable<IValidator<TRequest>> validators)
		{
			_validators = validators;
		}

        public async Task<TResponse> Handle(TRequest request, RequestHandlerDelegate<TResponse> next, CancellationToken cancellationToken)
        {
            var context = new ValidationContext<TRequest>(request);
            var failures = _validators
                .Select(v => v.Validate(context))
                .SelectMany(v => v.Errors)
                .Where(failure => failure != null)
                .ToList();

            if (failures.Any())
            {
                // Вернуть OperationResult с ошибками валидации
                var operationResult = new OperationResult { Success = false, Data = failures.Select(failure => failure.ErrorMessage).ToList() };

                if (typeof(TResponse) == typeof(OperationResult))
                {
                    return (TResponse)(object)operationResult;
                }
                else if (typeof(TResponse) == typeof(OperationResultPaged))
                {
                    // Вернуть OperationResultPaged с ошибками валидации
                    var operationResultPaged = new OperationResultPaged { Success = false, Data = operationResult.Data, Page = 0, PageSize = 0 };
                    return (TResponse)(object)operationResultPaged;
                }
                // Можете добавить другие типы TResponse и их обработку здесь

                // Если тип TResponse неизвестен или не соответствует ожидаемым типам, вернуть значение по умолчанию
                return default;
            }

            // Продолжить выполнение следующих обработчиков в пайплайне и вернуть результат
            return await next();
        }
    }
}

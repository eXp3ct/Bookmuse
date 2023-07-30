using Expect.Bookmuse.Domain;
using Expect.Bookmuse.Infrastructure.Common.Builders;
using FluentValidation;
using MediatR;

namespace Expect.Bookmuse.Infrastructure.Common.Behavior
{
    public class ValidationBehavior<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse> where TRequest : IRequest<TResponse>
    {
        private readonly IEnumerable<IValidator<TRequest>> _validators;
        private readonly IOperationResultBuilder _builder;

        public ValidationBehavior(IEnumerable<IValidator<TRequest>> validators, IOperationResultBuilder builder)
        {
            _validators = validators;
            _builder = builder;
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
                var operationResult = _builder
                    .AddData(failures.Select(failure => failure.ErrorMessage).ToList())
                    .Build();

                if (typeof(TResponse) == typeof(OperationResult))
                {
                    return (TResponse)(object)operationResult;
                }
                else if (typeof(TResponse) == typeof(OperationResultPaged))
                {
                    // Вернуть OperationResultPaged с ошибками валидации
                    var operationResultPaged = _builder.AddData(operationResult.Data).IsFailure().BuildPaged(0, 0);
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

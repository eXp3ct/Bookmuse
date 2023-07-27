using AutoMapper;
using Expect.Bookmuse.Domain;
using Expect.Bookmuse.Infrastructure.Commands.Common;
using Expect.Bookmuse.Infrastructure.Common.Interfaces;
using MediatR;
using Microsoft.Extensions.Logging;

namespace Expect.Bookmuse.Infrastructure.Commands.GetBook
{
	public class GetBookQueryHandler : QueryHandler<IdQuery, OperationResult>
	{
		public GetBookQueryHandler(ILogger<GetBookQueryHandler> logger, IMapper mapper, IAppDbContext context) : base(logger, mapper, context)
		{
		}

		public override async Task<OperationResult> Handle(IdQuery request, CancellationToken cancellationToken)
		{
			var book = await _context.Books
				.FindAsync(new object?[] { request.Id, cancellationToken }, cancellationToken: cancellationToken);

			var operationResult = new OperationResult
			{
				Data = book
			};

			if (book == null)
			{
				_logger.LogWarning($"Book with id {request.Id} not found");
				operationResult.Success = false;
				return operationResult;
			}

			_logger.LogInformation($"Returned book with id {book.Id}");

			return operationResult;
		}
	}
}

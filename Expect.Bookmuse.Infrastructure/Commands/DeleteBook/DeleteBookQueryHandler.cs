using AutoMapper;
using Expect.Bookmuse.Domain;
using Expect.Bookmuse.Infrastructure.Commands.Common;
using Expect.Bookmuse.Infrastructure.Common.Interfaces;
using MediatR;
using Microsoft.Extensions.Logging;

namespace Expect.Bookmuse.Infrastructure.Commands.DeleteBook
{
	public class DeleteBookQueryHandler : QueryHandler<IdQuery, OperationResult>
	{
		public DeleteBookQueryHandler(ILogger<DeleteBookQueryHandler> logger, IMapper mapper, IAppDbContext context) : base(logger, mapper, context)
		{
		}

		public override async Task<OperationResult> Handle(IdQuery request, CancellationToken cancellationToken)
		{
			var book = await _context.Books
				.FindAsync(new object?[] { request.Id, cancellationToken }, cancellationToken: cancellationToken);

			var operationResult = new OperationResult
			{
				Data = book,
			};

			if (book == null)
			{
				_logger.LogWarning($"Book with id {request.Id} not found");
				operationResult.Success = false;
				return operationResult;
			}

			_context.Books.Remove(book);
			var entitiesChanged = await _context.SaveChangesAsync(cancellationToken);

			if (entitiesChanged <= 0)
			{
				_logger.LogWarning($"Cannot remove book with id {book.Id}");
				operationResult.Success = false;
				return operationResult;
			}

			return operationResult;
		}
	}
}

using AutoMapper;
using Expect.Bookmuse.Domain;
using Expect.Bookmuse.Domain.Interfaces;
using Expect.Bookmuse.Infrastructure.Commands.Common;
using Expect.Bookmuse.Infrastructure.Commands.Common.Base;
using Expect.Bookmuse.Infrastructure.Common.Builders;
using Expect.Bookmuse.Infrastructure.Common.Interfaces;
using MediatR;
using Microsoft.Extensions.Logging;

namespace Expect.Bookmuse.Infrastructure.Commands.DeleteBook
{
	public class DeleteBookQueryHandler : QueryHandler<DeleteBookQuery, IOperationResult>
	{
        public DeleteBookQueryHandler(ILogger<QueryHandlerBase> logger, IMapper mapper, IAppDbContext context, IOperationResultBuilder builder) : base(logger, mapper, context, builder)
        {
        }

        public override async Task<IOperationResult> Handle(DeleteBookQuery request, CancellationToken cancellationToken)
		{
			var book = await _context.Books
				.FindAsync(new object?[] { request.Id, cancellationToken }, cancellationToken: cancellationToken);

			if (book == null)
			{
				_logger.LogWarning($"Book with id {request.Id} not found");
				return _builder
					.AddData(book)
					.IsFailure()
					.Build();
			}

			_context.Books.Remove(book);
			var entitiesChanged = await _context.SaveChangesAsync(cancellationToken);

			if (entitiesChanged <= 0)
			{
				_logger.LogWarning($"Cannot remove book with id {book.Id}");
                return _builder
                    .AddData(book)
                    .IsFailure()
                    .Build();
            }

			return _builder
				.AddData(book)
				.Build();
		}
	}
}

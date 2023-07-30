using AutoMapper;
using Expect.Bookmuse.Domain;
using Expect.Bookmuse.Domain.Interfaces;
using Expect.Bookmuse.Infrastructure.Commands.Common;
using Expect.Bookmuse.Infrastructure.Commands.Common.Base;
using Expect.Bookmuse.Infrastructure.Common.Builders;
using Expect.Bookmuse.Infrastructure.Common.Interfaces;
using MediatR;
using Microsoft.Extensions.Logging;

namespace Expect.Bookmuse.Infrastructure.Commands.GetBook
{
	public class GetBookQueryHandler : QueryHandler<GetBookQuery, IOperationResult>
	{
        public GetBookQueryHandler(ILogger<QueryHandlerBase> logger, IMapper mapper, IAppDbContext context, IOperationResultBuilder builder) : base(logger, mapper, context, builder)
        {
        }

        public override async Task<IOperationResult> Handle(GetBookQuery request, CancellationToken cancellationToken)
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

			_logger.LogInformation($"Returned book with id {book.Id}");

			return _builder
				.AddData(book)
				.Build();
		}
	}
}

using AutoMapper;
using Expect.Bookmuse.Domain;
using Expect.Bookmuse.Domain.Interfaces;
using Expect.Bookmuse.Infrastructure.Commands.Common;
using Expect.Bookmuse.Infrastructure.Commands.Common.Base;
using Expect.Bookmuse.Infrastructure.Common.Builders;
using Expect.Bookmuse.Infrastructure.Common.Interfaces;
using Microsoft.Extensions.Logging;

namespace Expect.Bookmuse.Infrastructure.Commands.BuyBook
{
	public class BuyBookQueryHandler : QueryHandler<BuyBookQuery, IOperationResult>
	{
        public BuyBookQueryHandler(ILogger<QueryHandlerBase> logger, IMapper mapper, IAppDbContext context, IOperationResultBuilder builder) : base(logger, mapper, context, builder)
        {
        }

        public override async Task<IOperationResult> Handle(BuyBookQuery request, CancellationToken cancellationToken)
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

			book.Sells += 1;
			await _context.SaveChangesAsync(cancellationToken);
			_logger.LogInformation($"Book with id {book.Id} was bought");

			return _builder
				.AddData(book)
				.Build();
		}
	}
}

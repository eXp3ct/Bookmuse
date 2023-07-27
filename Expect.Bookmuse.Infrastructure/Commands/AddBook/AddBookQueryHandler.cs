using AutoMapper;
using Expect.Bookmuse.Domain;
using Expect.Bookmuse.Infrastructure.Commands.Common;
using Expect.Bookmuse.Infrastructure.Common.Interfaces;
using MediatR;
using Microsoft.Extensions.Logging;

namespace Expect.Bookmuse.Infrastructure.Commands.AddBook
{
	public class AddBookQueryHandler : QueryHandler<AddBookQuery, OperationResult>
	{
		public AddBookQueryHandler(ILogger<AddBookQueryHandler> logger, IMapper mapper, IAppDbContext context) : base(logger, mapper, context)
		{
		}

		public override async Task<OperationResult> Handle(AddBookQuery request, CancellationToken cancellationToken)
		{
			var book = _mapper.Map<Book>(request.BookInfo);

			_logger.LogInformation($"Book with id {book.Id} created");

			await _context.Books.AddAsync(book, cancellationToken);
			await _context.SaveChangesAsync(cancellationToken);

			_logger.LogInformation($"Book with id {book.Id} saved to database");

			return new OperationResult
			{
				Data = book
			};
		}
	}
}

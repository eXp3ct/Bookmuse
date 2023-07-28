using AutoMapper;
using AutoMapper.QueryableExtensions;
using Expect.Bookmuse.Domain;
using Expect.Bookmuse.Infrastructure.Commands.Common;
using Expect.Bookmuse.Infrastructure.Commands.Common.Base;
using Expect.Bookmuse.Infrastructure.Common.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace Expect.Bookmuse.Infrastructure.Commands.GetBooksByProperties
{
	public class GetBooksByPropertiesQueryHandler : QueryHandler<GetBooksByPropertiesQuery, OperationResultPaged>
	{
		public GetBooksByPropertiesQueryHandler(ILogger<QueryHandlerBase> logger, IMapper mapper, IAppDbContext context) : base(logger, mapper, context)
		{
		}

		public override async Task<OperationResultPaged> Handle(GetBooksByPropertiesQuery request, CancellationToken cancellationToken)
		{
			var bookInfo = request.BookInfo;

			var matchingBooks = await _context.Books
				.Where(books =>
					books.Name == bookInfo.Name || 
					books.Author == bookInfo.Author ||
					books.ReleaseDate == bookInfo.ReleaseDate ||
					books.Genres == bookInfo.Genres || 
					books.Publisher == bookInfo.Publisher || 
					books.Volume == bookInfo.Volume)
				.Skip(request.Page * request.PageSize)
				.Take(request.PageSize)
				.ProjectTo<BookDto>(_mapper.ConfigurationProvider)
				.ToListAsync(cancellationToken);

			var operationResult = new OperationResultPaged
			{
				Data = matchingBooks,
				Page = request.Page,
				PageSize = request.PageSize
			};

			_logger.LogInformation($"Get {matchingBooks.Count} matching books");

			return operationResult;
		}
	}
}

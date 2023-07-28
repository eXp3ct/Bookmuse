using AutoMapper;
using AutoMapper.QueryableExtensions;
using Expect.Bookmuse.Domain;
using Expect.Bookmuse.Infrastructure.Commands.Common;
using Expect.Bookmuse.Infrastructure.Common.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace Expect.Bookmuse.Infrastructure.Commands.GetListOfBooks
{
	public class GetListOfBooksQueryHandler : QueryHandler<GetListOfBooksQuery, OperationResultPaged>
	{
		public GetListOfBooksQueryHandler(ILogger<GetListOfBooksQueryHandler> logger, IMapper mapper, IAppDbContext context) : base(logger, mapper, context)
		{ }

		public override async Task<OperationResultPaged> Handle(GetListOfBooksQuery request, CancellationToken cancellationToken)
		{
			var bookDtos = await _context.Books
				.Skip(request.Page * request.PageSize)
				.Take(request.PageSize)
				.OrderBy(x => x.Id)
				.ProjectTo<BookDto>(_mapper.ConfigurationProvider)
				.ToListAsync(cancellationToken);

			_logger.LogInformation($"Returned {bookDtos.Count} of books");


			return new OperationResultPaged
				{
					Data = bookDtos,
					Page = request.Page,
					PageSize = request.PageSize
				};
		}
	}
}

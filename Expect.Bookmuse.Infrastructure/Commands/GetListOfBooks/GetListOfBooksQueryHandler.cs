using AutoMapper;
using AutoMapper.QueryableExtensions;
using Expect.Bookmuse.Domain;
using Expect.Bookmuse.Domain.Interfaces;
using Expect.Bookmuse.Infrastructure.Commands.Common;
using Expect.Bookmuse.Infrastructure.Commands.Common.Base;
using Expect.Bookmuse.Infrastructure.Common.Builders;
using Expect.Bookmuse.Infrastructure.Common.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace Expect.Bookmuse.Infrastructure.Commands.GetListOfBooks
{
	public class GetListOfBooksQueryHandler : QueryHandler<GetListOfBooksQuery, IOperationResultPaged>
	{
        public GetListOfBooksQueryHandler(ILogger<QueryHandlerBase> logger, IMapper mapper, IAppDbContext context, IOperationResultBuilder builder) : base(logger, mapper, context, builder)
        {
        }

        public override async Task<IOperationResultPaged> Handle(GetListOfBooksQuery request, CancellationToken cancellationToken)
		{
			var bookDtos = await _context.Books
				.Skip((request.Page - 1) * request.PageSize)
				.Take(request.PageSize)
				.OrderBy(x => x.Id)
				.ProjectTo<BookDto>(_mapper.ConfigurationProvider)
				.ToListAsync(cancellationToken);

			_logger.LogInformation($"Returned {bookDtos.Count} of books");


			return _builder
				.AddData(bookDtos)
				.BuildPaged(request.Page, request.PageSize);
		}
	}
}

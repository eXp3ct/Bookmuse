﻿using AutoMapper;
using Expect.Bookmuse.Domain;
using Expect.Bookmuse.Domain.Interfaces;
using Expect.Bookmuse.Infrastructure.Commands.Common;
using Expect.Bookmuse.Infrastructure.Commands.Common.Base;
using Expect.Bookmuse.Infrastructure.Common.Builders;
using Expect.Bookmuse.Infrastructure.Common.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace Expect.Bookmuse.Infrastructure.Commands.AddBook
{
	public class AddBookQueryHandler : QueryHandler<AddBookQuery, IOperationResult>
	{
        public AddBookQueryHandler(ILogger<QueryHandlerBase> logger, IMapper mapper, IAppDbContext context, IOperationResultBuilder builder) : base(logger, mapper, context, builder)
        {
        }

        public override async Task<IOperationResult> Handle(AddBookQuery request, CancellationToken cancellationToken)
		{
			var book = _mapper.Map<Book>(request.BookInfo);
			var shelves = await _context.Shelves
				.ToListAsync(cancellationToken);
			var randomShelf = shelves[new Random().Next(0, shelves.Count)];
			book.ShelfId = randomShelf.Id;
			_logger.LogInformation($"Book with id {book.Id} created");

			await _context.Books.AddAsync(book, cancellationToken);
			await _context.SaveChangesAsync(cancellationToken);

			_logger.LogInformation($"Book with id {book.Id} saved to database");

			return _builder
				.AddData(book)
				.Build();
		}
	}
}

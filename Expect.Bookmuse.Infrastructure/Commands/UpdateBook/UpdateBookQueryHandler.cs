using AutoMapper;
using Expect.Bookmuse.Domain;
using Expect.Bookmuse.Domain.Interfaces;
using Expect.Bookmuse.Infrastructure.Commands.Common;
using Expect.Bookmuse.Infrastructure.Commands.Common.Base;
using Expect.Bookmuse.Infrastructure.Common.Builders;
using Expect.Bookmuse.Infrastructure.Common.Interfaces;
using Microsoft.Extensions.Logging;

namespace Expect.Bookmuse.Infrastructure.Commands.UpdateBook
{
	public class UpdateBookQueryHandler : QueryHandler<UpdateBookQuery, IOperationResult>
	{
        public UpdateBookQueryHandler(ILogger<QueryHandlerBase> logger, IMapper mapper, IAppDbContext context, IOperationResultBuilder builder) : base(logger, mapper, context, builder)
        {
        }

        public override async Task<IOperationResult> Handle(UpdateBookQuery request, CancellationToken cancellationToken)
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

			var bookInfo = request.BookInfo;

			// Получаем типы объектов
			var bookType = book.GetType();
			var bookInfoType = bookInfo.GetType();

			// Получаем все свойства в BookInfo, кроме Id и ShelfId
			var propertiesToCopy = bookInfoType.GetProperties()
				.Where(prop => prop.Name != "Id" && prop.Name != "ShelfId");

			foreach (var property in propertiesToCopy)
			{
				var bookInfoValue = property.GetValue(bookInfo);

				// Проверяем, есть ли свойство с таким же именем в Book и оно записываемое
				var bookProperty = bookType.GetProperty(property.Name);
				if (bookProperty != null && bookProperty.CanWrite)
				{
					bookProperty.SetValue(book, bookInfoValue);
				}
			}

			// Теперь объект book содержит значения свойств из bookInfo, кроме Id и ShelfId

			// Сохраняем изменения в базе данных
			await _context.SaveChangesAsync(cancellationToken);
			_logger.LogInformation($"Book with id {book.Id} changed");

			return _builder
				.AddData(book)
				.Build();
		}
	}
}

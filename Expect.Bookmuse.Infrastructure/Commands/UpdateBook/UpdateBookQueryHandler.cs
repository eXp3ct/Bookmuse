using AutoMapper;
using Expect.Bookmuse.Domain;
using Expect.Bookmuse.Infrastructure.Commands.Common;
using Expect.Bookmuse.Infrastructure.Common.Interfaces;
using Microsoft.Extensions.Logging;

namespace Expect.Bookmuse.Infrastructure.Commands.UpdateBook
{
	public class UpdateBookQueryHandler : QueryHandler<UpdateBookQuery, OperationResult>
	{
		public UpdateBookQueryHandler(ILogger<UpdateBookQueryHandler> logger, IMapper mapper, IAppDbContext context) : base(logger, mapper, context)
		{
		}

		public override async Task<OperationResult> Handle(UpdateBookQuery request, CancellationToken cancellationToken)
		{
			var book = await _context.Books
				.FindAsync(new object?[] { request.Id, cancellationToken }, cancellationToken: cancellationToken);

			if (book == null)
			{
				_logger.LogWarning($"Book with id {request.Id} not found");
				return new OperationResult
				{
					Data = request,
					Success = false
				};
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

			return new OperationResult()
			{
				Data = book,
			};
		}
	}
}

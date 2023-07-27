using Expect.Bookmuse.Domain;
using Expect.Bookmuse.Infrastructure.Commands.Common;
using MediatR;

namespace Expect.Bookmuse.Infrastructure.Commands.AddBook
{
	public class AddBookQuery : IRequest<OperationResult>
	{
		public BookInfo BookInfo { get; set; }
	}
}

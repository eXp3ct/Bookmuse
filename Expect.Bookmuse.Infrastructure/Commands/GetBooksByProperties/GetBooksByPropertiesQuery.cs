using Expect.Bookmuse.Domain;
using Expect.Bookmuse.Infrastructure.Commands.Common;
using MediatR;

namespace Expect.Bookmuse.Infrastructure.Commands.GetBooksByProperties
{
	public class GetBooksByPropertiesQuery : PagedQuery, IRequest<OperationResultPaged>
	{
		public BookInfo BookInfo { get; set; }
	}
}

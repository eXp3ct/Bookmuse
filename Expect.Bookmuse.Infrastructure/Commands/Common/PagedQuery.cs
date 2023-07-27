using Expect.Bookmuse.Domain;
using MediatR;

namespace Expect.Bookmuse.Infrastructure.Commands.Common
{
	public class PagedQuery : IRequest<OperationResultPaged>
	{
		public int Index { get; set; }
		public int PageSize { get; set; }
	}
}

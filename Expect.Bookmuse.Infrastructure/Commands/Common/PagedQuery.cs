using Expect.Bookmuse.Domain;
using MediatR;

namespace Expect.Bookmuse.Infrastructure.Commands.Common
{
	public class PagedQuery : IRequest<OperationResultPaged>
	{
		public int Page { get; set; }
		public int PageSize { get; set; }
	}
}

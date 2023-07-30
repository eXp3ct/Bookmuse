using Expect.Bookmuse.Domain;
using Expect.Bookmuse.Domain.Interfaces;
using MediatR;

namespace Expect.Bookmuse.Infrastructure.Commands.Common
{
	public class PagedQuery : IRequest<IOperationResultPaged>
	{
		public int Page { get; set; }
		public int PageSize { get; set; }
	}
}

using AutoMapper;
using Expect.Bookmuse.Infrastructure.Commands.Common.Base;
using Expect.Bookmuse.Infrastructure.Common.Interfaces;
using MediatR;
using Microsoft.Extensions.Logging;

namespace Expect.Bookmuse.Infrastructure.Commands.Common
{
	public abstract class QueryHandler<TRequest, TResponse> : QueryHandlerBase, IRequestHandler<TRequest, TResponse> where TRequest : IRequest<TResponse>
	{
		public QueryHandler(ILogger<QueryHandlerBase> logger, IMapper mapper, IAppDbContext context) : base(logger, mapper, context)
		{
		}

		public abstract Task<TResponse> Handle(TRequest request, CancellationToken cancellationToken);
	}
}

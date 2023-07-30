using AutoMapper;
using Expect.Bookmuse.Infrastructure.Commands.Common.Base;
using Expect.Bookmuse.Infrastructure.Common.Builders;
using Expect.Bookmuse.Infrastructure.Common.Interfaces;
using MediatR;
using Microsoft.Extensions.Logging;

namespace Expect.Bookmuse.Infrastructure.Commands.Common
{
	public abstract class QueryHandler<TRequest, TResponse> : QueryHandlerBase, IRequestHandler<TRequest, TResponse> where TRequest : IRequest<TResponse>
	{
        protected QueryHandler(ILogger<QueryHandlerBase> logger, IMapper mapper, IAppDbContext context, IOperationResultBuilder builder) : base(logger, mapper, context, builder)
        {
        }

        public abstract Task<TResponse> Handle(TRequest request, CancellationToken cancellationToken);
	}
}

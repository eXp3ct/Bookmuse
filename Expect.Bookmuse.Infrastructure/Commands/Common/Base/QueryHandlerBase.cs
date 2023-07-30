using AutoMapper;
using Expect.Bookmuse.Infrastructure.Common.Builders;
using Expect.Bookmuse.Infrastructure.Common.Interfaces;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Expect.Bookmuse.Infrastructure.Commands.Common.Base
{
	public abstract class QueryHandlerBase
	{
		protected readonly ILogger<QueryHandlerBase> _logger;
		protected readonly IMapper _mapper;
		protected readonly IAppDbContext _context;
		protected readonly IOperationResultBuilder _builder;

        public QueryHandlerBase(ILogger<QueryHandlerBase> logger, IMapper mapper, IAppDbContext context, IOperationResultBuilder builder)
        {
            _logger = logger;
            _mapper = mapper;
            _context = context;
            _builder = builder;
        }
    }
}

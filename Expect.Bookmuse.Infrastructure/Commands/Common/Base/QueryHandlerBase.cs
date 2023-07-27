using AutoMapper;
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

		public QueryHandlerBase(ILogger<QueryHandlerBase> logger, IMapper mapper, IAppDbContext context)
		{
			_logger = logger;
			_mapper = mapper;
			_context = context;
		}
	}
}

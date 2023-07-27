using Expect.Bookmuse.Domain;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Expect.Bookmuse.Infrastructure.Commands.Common
{
	public class IdQuery : IRequest<OperationResult>
	{
		public Guid Id { get; set; }
	}
}

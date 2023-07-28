using MassTransit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;

namespace Expect.Bookmuse.Infrastructure.Common.Consuming
{
	public abstract class ConsumerBase<TMessage> : IConsumer<TMessage> where TMessage : class
	{
		protected IMediator _mediator;

		protected ConsumerBase(IMediator mediator)
		{
			_mediator = mediator;
		}

		public abstract Task Consume(ConsumeContext<TMessage> context);
	}
}

using Expect.Bookmuse.Infrastructure.Commands.BuyBook;
using Expect.Bookmuse.Infrastructure.Common.Consuming;
using MassTransit;
using MediatR;

namespace Expect.Bookmuse.CrudService.Consumers
{
	public class BuyBookConsumer : ConsumerBase<BuyBookQuery>
	{
		public BuyBookConsumer(IMediator mediator) : base(mediator)
		{
		}

		public override async Task Consume(ConsumeContext<BuyBookQuery> context)
		{
			var response = await _mediator.Send(context.Message);

			await context.RespondAsync(response);
		}
	}
}

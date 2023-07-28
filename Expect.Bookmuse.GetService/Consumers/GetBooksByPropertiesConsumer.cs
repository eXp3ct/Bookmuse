using Expect.Bookmuse.Infrastructure.Commands.GetBooksByProperties;
using Expect.Bookmuse.Infrastructure.Common.Consuming;
using MassTransit;
using MediatR;

namespace Expect.Bookmuse.GetService.Consumers
{
	public class GetBooksByPropertiesConsumer : ConsumerBase<GetBooksByPropertiesQuery>
	{
		public GetBooksByPropertiesConsumer(IMediator mediator) : base(mediator)
		{
		}

		public override async Task Consume(ConsumeContext<GetBooksByPropertiesQuery> context)
		{
			var response = await _mediator.Send(context.Message);

			await context.RespondAsync(response);
		}
	}
}


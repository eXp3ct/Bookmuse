using Expect.Bookmuse.Infrastructure.Commands.GetBook;
using Expect.Bookmuse.Infrastructure.Common.Consuming;
using MassTransit;
using MediatR;

namespace Expect.Bookmuse.CrudService.Consumers
{
	public class GetBookConsumer : ConsumerBase<GetBookQuery>
	{
		public GetBookConsumer(IMediator mediator) : base(mediator)
		{
		}

		public override async Task Consume(ConsumeContext<GetBookQuery> context)
		{
			var response = await _mediator.Send(context.Message);

			await context.RespondAsync(response);
		}
	}
}

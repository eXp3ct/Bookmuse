using Expect.Bookmuse.Infrastructure.Commands.AddBook;
using Expect.Bookmuse.Infrastructure.Common.Consuming;
using MassTransit;
using MediatR;

namespace Expect.Bookmuse.CrudService.Consumers
{
	public class AddBookConsumer : ConsumerBase<AddBookQuery>
	{
		public AddBookConsumer(IMediator mediator) : base(mediator)
		{
		}

		public override async Task Consume(ConsumeContext<AddBookQuery> context)
		{
			var response = await _mediator.Send(context.Message);

			await context.RespondAsync(response);
		}
	}
}

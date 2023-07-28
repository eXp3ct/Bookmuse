using Expect.Bookmuse.Infrastructure.Commands.UpdateBook;
using Expect.Bookmuse.Infrastructure.Common.Consuming;
using MassTransit;
using MediatR;

namespace Expect.Bookmuse.CrudService.Consumers
{
	public class UpdateBookConsumer : ConsumerBase<UpdateBookQuery>
	{
		public UpdateBookConsumer(IMediator mediator) : base(mediator)
		{
		}

		public override async Task Consume(ConsumeContext<UpdateBookQuery> context)
		{
			var response = await _mediator.Send(context.Message);

			await context.RespondAsync(response);
		}
	}
}

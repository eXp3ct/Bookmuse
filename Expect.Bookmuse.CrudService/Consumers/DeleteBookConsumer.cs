using Expect.Bookmuse.Infrastructure.Commands.DeleteBook;
using Expect.Bookmuse.Infrastructure.Common.Consuming;
using MassTransit;
using MediatR;

namespace Expect.Bookmuse.CrudService.Consumers
{
	public class DeleteBookConsumer : ConsumerBase<DeleteBookQuery>
	{
		public DeleteBookConsumer(IMediator mediator) : base(mediator)
		{
		}

		public override async Task Consume(ConsumeContext<DeleteBookQuery> context)
		{
			var response = await _mediator.Send(context.Message);

			await context.RespondAsync(response);
		}
	}
}

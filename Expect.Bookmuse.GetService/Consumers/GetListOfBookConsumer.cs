using Expect.Bookmuse.Domain;
using Expect.Bookmuse.Infrastructure.Commands.GetListOfBooks;
using Expect.Bookmuse.Infrastructure.Common.Consuming;
using MassTransit;
using MediatR;

namespace Expect.Bookmuse.GetService.Consumers
{
	public class GetListOfBookConsumer : ConsumerBase<GetListOfBooksQuery>
	{
		public GetListOfBookConsumer(IMediator mediator) : base(mediator)
		{
		}


		public override async Task Consume(ConsumeContext<GetListOfBooksQuery> context)
		{
			var response = await _mediator.Send(context.Message);

			await context.RespondAsync(response);
		}
	}
}

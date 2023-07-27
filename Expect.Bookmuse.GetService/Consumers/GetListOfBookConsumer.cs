using Expect.Bookmuse.Domain;
using Expect.Bookmuse.Infrastructure.Commands.GetListOfBooks;
using MassTransit;
using MediatR;

namespace Expect.Bookmuse.GetService.Consumers
{
	public class GetListOfBookConsumer : IConsumer<GetListOfBooksQuery>
	{
		private readonly IMediator _mediator;

		public GetListOfBookConsumer(IMediator mediator)
		{
			_mediator = mediator;
		}

		public async Task Consume(ConsumeContext<GetListOfBooksQuery> context)
		{
			var response = await _mediator.Send(context.Message);

			await context.RespondAsync(response);
		}
	}
}

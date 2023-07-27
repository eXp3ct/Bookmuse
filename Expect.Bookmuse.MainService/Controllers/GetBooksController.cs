using Expect.Bookmuse.Domain;
using Expect.Bookmuse.Infrastructure.Commands.GetListOfBooks;
using Expect.Bookmuse.MainService.Controllers.Base;
using MassTransit;
using Microsoft.AspNetCore.Mvc;

namespace Expect.Bookmuse.MainService.Controllers
{
	[Route("api/[controller]")]
	public class GetBooksController : BaseController
	{
		public GetBooksController(ILogger<BaseController> logger, IBus bus) : base(logger, bus)
		{
		}

		[HttpPost]
		public async Task<IActionResult> GetListOfBooks([FromBody] GetListOfBooksQuery query)
		{
			_logger.LogInformation($"GetListOfBooksQuery has been sent to bus");
			var response = await _bus.Request<GetListOfBooksQuery, OperationResultPaged>(query);

			return Ok(response.Message);
		}
	}
}

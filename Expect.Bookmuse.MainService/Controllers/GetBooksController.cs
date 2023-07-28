using Expect.Bookmuse.Domain;
using Expect.Bookmuse.Infrastructure.Commands.GetBook;
using Expect.Bookmuse.Infrastructure.Commands.GetBooksByProperties;
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

		[HttpGet]
		[Route("/getbooks")]
		public async Task<IActionResult> GetListOfBooks(int page, int pageSize)
		{
			var query = new GetListOfBooksQuery()
			{
				Page = page,
				PageSize = pageSize
			};
			_logger.LogInformation($"GetListOfBooksQuery has been sent to bus");

			var response = await _bus.Request<GetListOfBooksQuery, OperationResultPaged>(query);

			_logger.LogInformation($"Returned an operation result for GetListOfBooksQuery");
			return Ok(response.Message);
		}

		[HttpPost]
		[Route("/getbooks")]
		public async Task<IActionResult> GetListOfBooksByProperties([FromBody] GetBooksByPropertiesQuery query)
		{
			_logger.LogInformation("GetBooksByPropertiesQuery has been sent to bus");

			var response = await _bus.Request<GetBooksByPropertiesQuery, OperationResultPaged>(query);

			_logger.LogInformation($"Returned an operation result for GetListOfBooksQuery");

			return Ok(response.Message);
		}

		[HttpGet]
		[Route("/getbook/{id}")]
		public async Task<IActionResult> GetBook(Guid id)
		{
			var query = new GetBookQuery()
			{
				Id = id
			};

			_logger.LogInformation("GetBookQuery has been sent to bus");
			var response = await _bus.Request<GetBookQuery, OperationResult>(query);

			_logger.LogInformation("Returned an operation result for GetBookQuery");

			return Ok(response.Message);	
		}
	}
}

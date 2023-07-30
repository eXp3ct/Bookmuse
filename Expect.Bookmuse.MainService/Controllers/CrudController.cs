using Expect.Bookmuse.Domain;
using Expect.Bookmuse.Infrastructure.Commands.AddBook;
using Expect.Bookmuse.Infrastructure.Commands.BuyBook;
using Expect.Bookmuse.Infrastructure.Commands.DeleteBook;
using Expect.Bookmuse.Infrastructure.Commands.UpdateBook;
using Expect.Bookmuse.MainService.Controllers.Base;
using MassTransit;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Abstractions;

namespace Expect.Bookmuse.MainService.Controllers
{
	[Route("[controller]")]
	public class CrudController : BaseController
	{
		public CrudController(ILogger<BaseController> logger, IBus bus) : base(logger, bus)
		{
		}

		[HttpPost]
		[Route("/addbook")]
		public async Task<IActionResult> AddBook([FromBody] AddBookQuery query)
		{
			_logger.LogInformation("AddBookQuery has been sent to bus");
			var response = await _bus.Request<AddBookQuery, OperationResult>(query);

			_logger.LogInformation("Returned an operation result for AddBookQuery");
			if (!response.Message.Success)
			{
				return BadRequest(response.Message);
			}
			return Created("/",response.Message);
		}

		[HttpPost]
		[Route("/buybook")]
		public async Task<IActionResult> BuyBook([FromBody] BuyBookQuery query)
		{
			_logger.LogInformation("BuyBookQuery has been sent to bus");
			var response = await _bus.Request<BuyBookQuery, OperationResult>(query);
			if (!response.Message.Success)
			{
				return BadRequest(response.Message);
			}
			_logger.LogInformation("Returned an operation result for BuyBookQuery");
			return Ok(response.Message);
		}

		[HttpDelete]
		[Route("/deletebook")]
		public async Task<IActionResult> DeleteBook([FromBody] DeleteBookQuery query)
		{
			_logger.LogInformation("DeleteBookQuery has been sent to bus");
			var response = await _bus.Request<DeleteBookQuery, OperationResult>(query);
			if (!response.Message.Success)
			{
				return BadRequest(response.Message);
			}
			_logger.LogInformation("Returned an operation result for DeleteBookQuery");

			return Ok(response.Message);
		}

		[HttpPost]
		[Route("/updatebook")]
		public async Task<IActionResult> UpdateBook([FromBody] UpdateBookQuery query)
		{
			_logger.LogInformation("UpdateBookQuery has been sent to bus");
			var response = await _bus.Request<UpdateBookQuery, OperationResult>(query);
			if (!response.Message.Success)
			{
				return BadRequest(response.Message);
			}
			_logger.LogInformation("Returned an operation result for UpdateBookQuery");
			return Ok(response.Message);
		}

	}
}

using Expect.Bookmuse.Domain;
using Expect.Bookmuse.Domain.Interfaces;
using Expect.Bookmuse.Infrastructure.Commands.AddBook;
using Expect.Bookmuse.Infrastructure.Commands.BuyBook;
using Expect.Bookmuse.Infrastructure.Commands.DeleteBook;
using Expect.Bookmuse.Infrastructure.Commands.UpdateBook;
using Expect.Bookmuse.MainService.Controllers.Base;
using MassTransit;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Abstractions;

namespace Expect.Bookmuse.MainService.Controllers
{
	/// <summary>
	/// Операции CRUD для книг
	/// </summary>
	[Route("api/[controller]")]
	[Authorize("getbooks")]
	public class CrudController : BaseController
	{
		/// <summary>
		/// 
		/// </summary>
		/// <param name="logger"></param>
		/// <param name="bus"></param>
		public CrudController(ILogger<BaseController> logger, IBus bus) : base(logger, bus)
		{
		}

		/// <summary>
		/// Добавление книги в БД
		/// </summary>
		/// <param name="query"></param>
		/// <returns>IOpeartionResult</returns>
		[HttpPost]
		[ProducesResponseType(StatusCodes.Status201Created, Type= typeof(OperationResult))]
		[ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(OperationResult))]
		public async Task<IActionResult> AddBook([FromBody] AddBookQuery query)
		{
			_logger.LogInformation("AddBookQuery has been sent to bus");
			var response = await _bus.Request<AddBookQuery, IOperationResult>(query);

			_logger.LogInformation("Returned an operation result for AddBookQuery");
			if (!response.Message.Success)
			{
				return BadRequest(response.Message);
			}
			return Created("/",response.Message);
		}

		/// <summary>
		/// Покупка книги
		/// </summary>
		/// <param name="id">Id книги</param>
		/// <returns>IOpeartionResult</returns>
		[HttpPut]
		[Route("{id}")]
		[ProducesResponseType(StatusCodes.Status201Created, Type = typeof(OperationResult))]
		[ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(OperationResult))]
		public async Task<IActionResult> BuyBook([FromRoute] Guid id)
		{
			var query = new BuyBookQuery { Id = id };
			_logger.LogInformation("BuyBookQuery has been sent to bus");
			var response = await _bus.Request<BuyBookQuery, IOperationResult>(query);
			if (!response.Message.Success)
			{
				return BadRequest(response.Message);
			}
			_logger.LogInformation("Returned an operation result for BuyBookQuery");
			return Ok(response.Message);
		}

		/// <summary>
		/// Удаление книги из БД
		/// </summary>
		/// <param name="id">Id книги</param>
		/// <returns>IOpeartionResult</returns>
		[HttpDelete]
		[Route("{id}")]
		[ProducesResponseType(StatusCodes.Status201Created, Type= typeof(OperationResult))]
		[ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(OperationResult))]
		public async Task<IActionResult> DeleteBook([FromRoute] Guid id)
		{
			var query = new DeleteBookQuery { Id = id };
			_logger.LogInformation("DeleteBookQuery has been sent to bus");
			var response = await _bus.Request<DeleteBookQuery, IOperationResult>(query);
			if (!response.Message.Success)
			{
				return BadRequest(response.Message);
			}
			_logger.LogInformation("Returned an operation result for DeleteBookQuery");

			return Ok(response.Message);
		}

		/// <summary>
		/// Обновление информации о книге
		/// </summary>
		/// <param name="id">Id книги</param>
		/// <param name="info">Информация о книге</param>
		/// <returns>IOpeartionResult</returns>
		[HttpPost]
		[Route("{id}")]
		[ProducesResponseType(StatusCodes.Status201Created, Type= typeof(OperationResult))]
		[ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(OperationResult))]
		public async Task<IActionResult> UpdateBook([FromRoute] Guid id, [FromBody] BookInfo info)
		{
			var query = new UpdateBookQuery
			{
				Id = id,
				BookInfo = info
			};
			_logger.LogInformation("UpdateBookQuery has been sent to bus");
			var response = await _bus.Request<UpdateBookQuery, IOperationResult>(query);
			if (!response.Message.Success)
			{
				return BadRequest(response.Message);
			}
			_logger.LogInformation("Returned an operation result for UpdateBookQuery");
			return Ok(response.Message);
		}

	}
}

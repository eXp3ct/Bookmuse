using Expect.Bookmuse.Domain;
using Expect.Bookmuse.Domain.Interfaces;
using Expect.Bookmuse.Infrastructure.Commands.GetBook;
using Expect.Bookmuse.Infrastructure.Commands.GetBooksByProperties;
using Expect.Bookmuse.Infrastructure.Commands.GetListOfBooks;
using Expect.Bookmuse.MainService.Controllers.Base;
using MassTransit;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Net.Mime;

namespace Expect.Bookmuse.MainService.Controllers
{
	/// <summary>
	/// Контроллер для получения книг
	/// </summary>
	[Route("api/[controller]")]
	[Authorize]
	[ApiController]
	public class GetBooksController : BaseController
	{
		/// <summary>
		/// 
		/// </summary>
		/// <param name="logger"></param>
		/// <param name="bus"></param>
		public GetBooksController(ILogger<BaseController> logger, IBus bus) : base(logger, bus)
		{
		}

		/// <summary>
		/// Получение списка всех книг
		/// </summary>
		/// <param name="page">Страница</param>
		/// <param name="pageSize">Размер страницы</param>
		/// <returns>Список книг</returns>
		[HttpGet]
		[ProducesResponseType(StatusCodes.Status201Created, Type = typeof(OperationResultPaged))]
		[ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(OperationResultPaged))]
		public async Task<IActionResult> GetListOfBooks(int page, int pageSize)
		{
			var query = new GetListOfBooksQuery()
			{
				Page = page,
				PageSize = pageSize
			};
			_logger.LogInformation($"GetListOfBooksQuery has been sent to bus {query.Page} | {query.PageSize}");

			var response = await _bus.Request<GetListOfBooksQuery, IOperationResultPaged>(query);
            if (!response.Message.Success)
            {
                return BadRequest(response.Message);
            }
            _logger.LogInformation($"Returned an operation result for GetListOfBooksQuery");
			return Ok(response.Message);
		}

		/// <summary>
		/// Получение списка книг по какому то полю
		/// </summary>
		/// <param name="query">Поля по которым искать</param>
		/// <returns>Список книг</returns>
		[HttpPost]
		[ProducesResponseType(StatusCodes.Status201Created, Type = typeof(OperationResultPaged))]
		[ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(OperationResultPaged))]
		public async Task<IActionResult> GetListOfBooksByProperties([FromBody] GetBooksByPropertiesQuery query)
		{
			_logger.LogInformation("GetBooksByPropertiesQuery has been sent to bus");

			var response = await _bus.Request<GetBooksByPropertiesQuery, IOperationResultPaged>(query);
			if (!response.Message.Success)
			{
				return BadRequest(response.Message);
			}
			_logger.LogInformation($"Returned an operation result for GetListOfBooksQuery");

			return Ok(response.Message);
		}


		/// <summary>
		/// Получение книги
		/// </summary>
		/// <param name="id">Id книги</param>
		/// <returns>Книга</returns>
		[HttpGet]
		[Route("{id}")]
		[ProducesResponseType(StatusCodes.Status201Created, Type = typeof(OperationResultPaged))]
		[ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(OperationResultPaged))]
		public async Task<IActionResult> GetBook([FromRoute] Guid id)
		{
			var query = new GetBookQuery()
			{
				Id = id
			};

			_logger.LogInformation("GetBookQuery has been sent to bus");
			var response = await _bus.Request<GetBookQuery, IOperationResult>(query);
			if (!response.Message.Success)
			{
				return BadRequest(response.Message);
			}
			_logger.LogInformation("Returned an operation result for GetBookQuery");

			return Ok(response.Message);	
		}
	}
}

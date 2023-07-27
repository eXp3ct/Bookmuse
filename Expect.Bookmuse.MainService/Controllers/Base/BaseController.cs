using MassTransit;
using Microsoft.AspNetCore.Mvc;

namespace Expect.Bookmuse.MainService.Controllers.Base
{
	[ApiController]
	public abstract class BaseController : Controller
	{
		protected readonly ILogger<BaseController> _logger;
		protected readonly IBus _bus;

		protected BaseController(ILogger<BaseController> logger, IBus bus)
		{
			_logger = logger;
			_bus = bus;
		}
	}
}

using MassTransit;
using Microsoft.AspNetCore.Mvc;

namespace Expect.Bookmuse.MainService.Controllers.Base
{

	public abstract class BaseController : ControllerBase
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

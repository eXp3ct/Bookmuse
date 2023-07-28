using Expect.Bookmuse.CrudService.Consumers;
using Expect.Bookmuse.Data;
using Expect.Bookmuse.Domain;
using Expect.Bookmuse.Infrastructure;
using MassTransit;
using Microsoft.EntityFrameworkCore;

namespace Expect.Bookmuse.CrudService
{
	public class Startup
	{
		public IConfiguration Configuration { get; set; }

		public Startup(IConfiguration configuration)
		{
			Configuration = configuration;
		}

		public void Configure(IApplicationBuilder app, IWebHostEnvironment environment)
		{

		}

		public void ConfigureServices(IServiceCollection services)
		{
			services.AddPersistance(Configuration);
			services.AddInfrastructure();
			services.AddMassTransit(configurator =>
			{
				configurator.SetKebabCaseEndpointNameFormatter();
				configurator.AddConsumer<AddBookConsumer>();
				configurator.AddConsumer<BuyBookConsumer>();
				configurator.AddConsumer<DeleteBookConsumer>();
				configurator.AddConsumer<GetBookConsumer>();
				configurator.AddConsumer<UpdateBookConsumer>();

				configurator.UsingRabbitMq((context, config) =>
				{
					var rabbitMqConfig = Configuration.GetSection("RabbitMqConfig")
						.Get<RabbitMqConfigurator>();

					config.Host(rabbitMqConfig.Host, "/", h =>
					{
						h.Username(rabbitMqConfig.Username);
						h.Password(rabbitMqConfig.Password);
					});

					config.ConfigureEndpoints(context);
				});
			});
		}
	}
}

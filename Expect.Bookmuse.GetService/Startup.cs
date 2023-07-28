using Expect.Bookmuse.Data;
using Expect.Bookmuse.Domain;
using Expect.Bookmuse.GetService.Consumers;
using Expect.Bookmuse.Infrastructure;
using MassTransit;

namespace Expect.Bookmuse.GetService
{
	public class Startup
	{
		public IConfiguration Configuration { get; set; }

		public Startup(IConfiguration configuration)
		{
			Configuration = configuration;
		}

		public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
		{

		}

		public void ConfigureServices(IServiceCollection services)
		{
			services.AddInfrastructure();
			services.AddPersistance(Configuration);
			services.AddMassTransit(x =>
			{
				x.SetKebabCaseEndpointNameFormatter();
				x.AddConsumer<GetListOfBookConsumer>();
				x.AddConsumer<GetBooksByPropertiesConsumer>();

				x.UsingRabbitMq((context, configuration) =>
				{
					var rabbitMqConfig = Configuration.GetSection("RabbitMqConfig")
									   .Get<RabbitMqConfigurator>();

					configuration.Host(rabbitMqConfig.Host, "/", h =>
					{
						h.Username(rabbitMqConfig.Username);
						h.Password(rabbitMqConfig.Password);
					});

					configuration.ConfigureEndpoints(context);
				});
			});
		}
	}
}

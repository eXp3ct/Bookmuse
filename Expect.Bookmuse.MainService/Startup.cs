using Expect.Bookmuse.Domain;
using MassTransit;

namespace Expect.Bookmuse.MainService
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
			if (env.IsDevelopment())
			{
				app.UseSwagger();
				app.UseSwaggerUI();
			}

			app.UseHttpsRedirection();
			app.UseRouting();
			app.UseAuthorization();
			app.UseCors(policeBuilder =>
			{
				policeBuilder.AllowAnyHeader();
				policeBuilder.AllowAnyOrigin();
				policeBuilder.AllowAnyMethod();
			});
			app.UseEndpoints(endpoints =>
			{
				endpoints.MapControllers();
			});

		}

		public void ConfigureServices(IServiceCollection services)
		{
			services.AddControllers();
			services.AddEndpointsApiExplorer();
			services.AddSwaggerGen();

			services.AddMassTransit(x =>
			{
				x.SetKebabCaseEndpointNameFormatter();
				x.AddBus(provider => Bus.Factory.CreateUsingRabbitMq(cfg =>
				{
					var rabbitMqConfig = Configuration.GetSection("RabbitMqConfig")
									   .Get<RabbitMqConfigurator>();

					cfg.Host(rabbitMqConfig.Host, "/", h =>
					{
						h.Username(rabbitMqConfig.Username);
						h.Password(rabbitMqConfig.Password);
					});
				}));
			});
		}
	}
}

using Expect.Bookmuse.Domain;
using MassTransit;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;

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
			app.UseAuthentication();
			//app.UseCors(policeBuilder =>
			//{
			//	policeBuilder.AllowAnyHeader();
			//	policeBuilder.AllowAnyOrigin();
			//	policeBuilder.AllowAnyMethod();
			//});
			app.UseEndpoints(endpoints =>
			{
				endpoints.MapControllers();
			});

		}

		public void ConfigureServices(IServiceCollection services)
		{
			services.AddControllers();
			services.AddEndpointsApiExplorer();
			SwaggerConfiguration.Configure(services);

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

			// Добавляем аутентификацию с помощью токенов
			services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
				.AddJwtBearer(JwtBearerDefaults.AuthenticationScheme, options =>
				{
					options.Authority = "https://auth:443"; // URL вашего IdentityServer
					options.Audience = "getbooks";

					// Отключаем проверку SSL соединения
					options.BackchannelHttpHandler = new HttpClientHandler
					{
						ServerCertificateCustomValidationCallback = (sender, cert, chain, sslPolicyErrors) => true
					};
				});

			services.AddAuthorization(options =>
			{
				options.AddPolicy("getbooks", policy =>
				{
					policy.RequireClaim("client_controller", "getbooks");
				});
			});
		}
	}
}

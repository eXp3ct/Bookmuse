using Expect.Bookmuse.Auth.Data;
using IdentityServer4.Test;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;

namespace Expect.Bookmuse.Auth
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
			app.UseHttpsRedirection();
			app.UseRouting();
			app.UseAuthentication();
			app.UseIdentityServer();
			app.UseCors(builder =>
			{
				builder.AllowAnyOrigin();
				builder.AllowAnyMethod();
				builder.AllowAnyHeader();
			});
		}

		public void ConfigureServices(IServiceCollection services)
		{
			// Добавляем и настраиваем IdentityServer
			services.AddIdentityServer()
				.AddInMemoryClients(IdentityServerConfig.GetClients()) // Метод, который будет содержать настройки для клиентов
				.AddInMemoryApiScopes(IdentityServerConfig.GetApiScopes())
				.AddDeveloperSigningCredential();		
		}
	}
}

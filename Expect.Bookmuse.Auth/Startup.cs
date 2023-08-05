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
			app.UseIdentityServer();
		}

		public void ConfigureServices(IServiceCollection services)
		{
			// Добавляем и настраиваем IdentityServer
			services.AddIdentityServer()
				.AddInMemoryApiResources(IdentityServerConfig.GetApiResources())
				.AddInMemoryClients(IdentityServerConfig.GetClients())
				.AddInMemoryApiScopes(IdentityServerConfig.GetApiScopes())
				//.AddInMemoryIdentityResources(IdentityServerConfig.GetIdentityResources())
				.AddDeveloperSigningCredential();	
			
			services.AddAuthorization();
		}
	}
}

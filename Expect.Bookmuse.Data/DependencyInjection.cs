using Expect.Bookmuse.Infrastructure.Common.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Expect.Bookmuse.Data
{
	public static class DependencyInjection
	{
		public static IServiceCollection AddPersistance(this IServiceCollection services, IConfiguration configuration)
		{
			var connectionString = configuration.GetConnectionString("DefaultConnection");
			services.AddDbContext<AppDbContext>(options =>
			{
				options.UseNpgsql(connectionString);
			});
			services.AddScoped<IAppDbContext, AppDbContext>();

			return services;
		}
	}
}

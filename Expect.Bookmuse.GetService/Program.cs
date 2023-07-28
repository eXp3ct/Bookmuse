using Expect.Bookmuse.Data;
using Microsoft.EntityFrameworkCore;

namespace Expect.Bookmuse.GetService
{
	public class Program
	{
		public static void Main(string[] args)
		{
			var host = CreateHostBuilder(args).Build();
			var services = host.Services.CreateScope();
			var context = services.ServiceProvider.GetRequiredService<AppDbContext>();
			context.Database.Migrate();
			host.Run();
		}

		public static IHostBuilder CreateHostBuilder(string[] args) =>
			Host.CreateDefaultBuilder(args)
			.ConfigureWebHostDefaults(builder =>
			{
				builder.UseStartup<Startup>();
			});
	}
}
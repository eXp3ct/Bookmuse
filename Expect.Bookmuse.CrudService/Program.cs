using Expect.Bookmuse.Data;

namespace Expect.Bookmuse.CrudService
{
	public class Program
	{
		public static void Main(string[] args)
		{
			var host = CreateHostBuilder(args).Build();

			var services = host.Services.CreateScope();
			var context = services.ServiceProvider.GetRequiredService<AppDbContext>();
			context.Database.EnsureCreated();

			host.Run();
		}

		public static IHostBuilder CreateHostBuilder(string[] args) =>
			Host.CreateDefaultBuilder(args)
				.ConfigureWebHostDefaults(webBuilder =>
				{
					webBuilder.UseStartup<Startup>();
				});
	}
}

using Serilog;

namespace Expect.Bookmuse.MainService
{
	public class Program
	{
		public static void Main(string[] args)
		{
			var host = CreateHostBuilder(args).Build();

			host.Run();
		}

		public static IHostBuilder CreateHostBuilder(string[] args) => 
			Host.CreateDefaultBuilder(args)
				.UseSerilog((context, config) =>
				{
					config
						.MinimumLevel.Information()
						.WriteTo.Console();
				})
				.ConfigureWebHostDefaults(builder => 
				{
					builder.UseStartup<Startup>();
				});
	}
}
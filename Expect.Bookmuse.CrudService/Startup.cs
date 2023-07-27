using Expect.Bookmuse.Data;
using Expect.Bookmuse.Infrastructure;

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
		}
	}
}

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
		}
	}
}

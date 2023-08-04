using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace Expect.Bookmuse.MainService
{
	public static class SwaggerConfiguration
	{
		public static void Configure(IServiceCollection services)
		{
			services.AddSwaggerGen(options =>
			{
				options.SwaggerDoc("v1", new Microsoft.OpenApi.Models.OpenApiInfo
				{
					Title = "Bookmuse API",
					Version = "v1",
					Description = "API для управления электронной библиотекой Bookmuse"
				});

				// Добавляем комментарии из XML-документации в документацию Swagger (если они есть)
				var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
				var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
				options.IncludeXmlComments(xmlPath);
			});
		}
	}
}

using InnoTree.Infrastructure.Context;
using Microsoft.EntityFrameworkCore;

namespace InnoTree.API.Extensions;

public static class DependencyInjection
{
	public static void ConfigureDbContext(this IServiceCollection services, WebApplicationBuilder builder)
	{
		services.AddDbContext<InnoTreeDbContext>(options =>
		{
			options.UseNpgsql(builder.Configuration.GetConnectionString("connectionString"));
		});
	}

	public static void ConfigureCors(this IServiceCollection services)
	{
		services.AddCors(options =>
		{
			options.AddPolicy("CorsPolicy", builder =>
			builder.AllowAnyOrigin()
			.AllowAnyMethod()
			.AllowAnyHeader());
		});
	}
}

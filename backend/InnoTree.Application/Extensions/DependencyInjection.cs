using InnoTree.Application.MapperProfiles;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace InnoTree.Application.Extensions;

public static class DependencyInjection
{
	public static void ConfigureAutomapper(this IServiceCollection services)
	{
		services.AddAutoMapper(options =>
		{
			options.AddProfile<DecorationMapperProfile>();
		});
	}

	public static void ConfigureMediatr(this IServiceCollection services)
	{
		services.AddMediatR(config =>
		{
			config.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly());
		});
	}
}

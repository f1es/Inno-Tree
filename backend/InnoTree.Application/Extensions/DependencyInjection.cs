using FluentValidation;
using InnoTree.Application.MapperProfiles;
using InnoTree.Application.MediatR.PipelineBehaviors;
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

			config.AddOpenBehavior(typeof(ValidationBehavior<,>));
		});
	}

	public static void ConfigureValidators(this IServiceCollection services)
	{
		services.AddValidatorsFromAssembly(Assembly.GetExecutingAssembly());
	}
}

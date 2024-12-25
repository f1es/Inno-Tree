using InnoTree.Core.Repositories.Interfaces;
using InnoTree.Infrastructure.Repositories.Implementations;
using Microsoft.Extensions.DependencyInjection;

namespace InnoTree.Infrastructure.Extensions;

public static class DependencyInjection
{
	public static void ConfigureRepositories(this IServiceCollection services)
	{
		services.AddScoped<IUnitOfWork, UnitOfWork>();
	}
}

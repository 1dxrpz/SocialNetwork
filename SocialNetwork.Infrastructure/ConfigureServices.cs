using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using SocialNetwork.Infrastructure.Data.Contexts;

namespace SocialNetwork.Infrastructure
{
	public static class ConfigureServices
	{
		public static IServiceCollection AddInfrastructure(
			this IServiceCollection services,
			IConfiguration configuration)
		{
			services.AddEntityFrameworkNpgsql()
				.AddDbContext<ApplicationContext>(options =>
					options.UseNpgsql(configuration["DefaultConnection"])
				);
			return services;
		}
	}
}

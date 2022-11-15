using SocialNetwork.Domain.Interfaces;
using SocialNetwork.Domain.Interfaces.Services;
using SocialNetwork.Infrastructure.Data;
using SocialNetwork.Server.Services;

namespace SocialNetwork.Server.Extensions
{
	public static class ServicesExtensions
	{
		public static IServiceCollection ConfigureServices(this IServiceCollection services)
		{
			services.AddScoped<IUnitOfWork, UnitOfWork>();
			services.AddScoped<IUserService, UserService>();
			return services;
		}
	}
}

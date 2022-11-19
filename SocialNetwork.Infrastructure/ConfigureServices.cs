using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using SocialNetwork.Infrastructure.Data.Contexts;
using SocialNetwork.Infrastructure.Data.MappingProfiles;
using System.Text;

namespace SocialNetwork.Infrastructure
{
	public static class ConfigureServices
	{
		public static IServiceCollection AddInfrastructure(
			this IServiceCollection services,
			IConfiguration configuration)
		{
			services.AddCors(options =>
			{
				options.AddPolicy(name: "All",
					policy =>
					{
						policy
							.AllowAnyOrigin()
							.AllowAnyMethod()
							.AllowAnyHeader();
					});
			});
			services.AddEntityFrameworkNpgsql()
				.AddDbContext<ApplicationContext>(options =>
					options.UseNpgsql(configuration["DefaultConnection"])
				);
			services.AddAutoMapper(typeof(AppMappingProfile));
			
			services.AddAuthentication(options =>
				{
					options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
					options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
				})
				.AddJwtBearer(options =>
				{
					options.RequireHttpsMetadata = false;
					options.SaveToken = true;
					options.TokenValidationParameters = new TokenValidationParameters
					{
						ValidateIssuerSigningKey = true,
						IssuerSigningKey = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(configuration["TokenSecret"])),
						ValidateIssuer = false,
						ValidateAudience = false
					};
				});
			services.AddAuthorization();
			
			return services;
		}
	}
}

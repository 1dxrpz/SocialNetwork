using Microsoft.EntityFrameworkCore;
using SocialNetwork.Domain.Entity;

namespace SocialNetwork.Infrastructure.Data.Contexts
{
	public class ApplicationContext : DbContext
	{
		DbSet<User> Users { get; set; }
		DbSet<Friend> Friends { get; set; }
		DbSet<Article> Articles { get; set; }
		public ApplicationContext(DbContextOptions<ApplicationContext> options)
			: base(options)
		{
			Database.EnsureCreated();
		}
	}
}
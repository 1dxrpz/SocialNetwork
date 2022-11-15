using SocialNetwork.Domain.Interfaces;
using System.ComponentModel.DataAnnotations;

namespace SocialNetwork.Domain.Entity
{
	public class User : IEntity
	{
		public Guid Id { get; set; }
		public Guid AvatarID { get; set; }
		[Required, MinLength(6), MaxLength(120)]
		public string Name { get; set; }
		[Required, MinLength(6), MaxLength(32)]
		public string Password { get; set; }
		[Required, MinLength(6), MaxLength(32)]
		public string Login { get; set; }
		[Required]
		public string Email { get; set; }
	}
}

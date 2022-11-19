using Microsoft.AspNetCore.Http;

namespace SocialNetwork.Domain.ViewModels
{
	public class AvatarUpload
	{
		IFormFile file { get; set; }
	}
}

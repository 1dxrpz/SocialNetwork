using Microsoft.AspNetCore.Http;

namespace SocialNetwork.Domain.Interfaces.Services
{
	public interface IUploadService
	{
		Task Upload(IFormFile file, Guid id);
	}
}

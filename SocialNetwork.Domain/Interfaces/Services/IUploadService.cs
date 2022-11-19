using Microsoft.AspNetCore.Http;

namespace SocialNetwork.Domain.Interfaces.Services
{
	public interface IUploadService
	{
		Task<Guid> UploadImage(IFormFile file);
		Task<Guid> UploadVideo(IFormFile file);
		Task<Guid> UploadAudio(IFormFile file);
		Task<byte[]> GetImage(Guid id);
		Task<byte[]> GetVideo(Guid id);
		Task<byte[]> GetAudio(Guid id);
	}
}

using SocialNetwork.Domain.Interfaces.Services;

namespace SocialNetwork.Server.Services
{
	public class UploadService : IUploadService
	{
		IWebHostEnvironment _environment;
		public UploadService(IWebHostEnvironment environment)
		{
			_environment = environment;
		}

		public async Task Upload(IFormFile file, Guid id)
		{
			var path = Path.Combine(_environment.ContentRootPath, "Images");
			var filepath = Path.Combine(path, id.ToString());
			using (var stream = new FileStream(filepath, FileMode.Create))
			{
				await file.CopyToAsync(stream);
			}
		}
	}
}

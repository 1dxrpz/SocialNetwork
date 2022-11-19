using Microsoft.AspNetCore.Mvc;
using SocialNetwork.Domain.Enums;
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
		private async Task<Guid> Upload(IFormFile file, FileType fileType)
		{
			string folder = fileType switch
			{
				FileType.Image => "Images",
				FileType.Video => "Videos",
				FileType.Audio => "Audios",
				_ => throw new NotImplementedException()
			};
			Guid id = Guid.NewGuid();
			var path = Path.Combine(_environment.ContentRootPath, folder);
			var filepath = Path.Combine(path, id.ToString());
			using (var stream = new FileStream(filepath, FileMode.Create))
			{
				await file.CopyToAsync(stream);
			}
			return id;
		}
		private async Task<byte[]?> Get(Guid id, FileType fileType)
		{
			string folder = fileType switch
			{
				FileType.Image => "Images",
				FileType.Video => "Videos",
				FileType.Audio => "Audios",
				_ => throw new NotImplementedException()
			};
			try
			{
				var path = Path.Combine(_environment.ContentRootPath, folder);
				var filepath = Path.Combine(path, id.ToString());
				return await File.ReadAllBytesAsync(filepath);
			}
			catch
			{
				return null;
			}
		}

		public async Task<Guid> UploadImage(IFormFile file) => await Upload(file, FileType.Image);
		public async Task<Guid> UploadVideo(IFormFile file) => await Upload(file, FileType.Video);
		public async Task<Guid> UploadAudio(IFormFile file) => await Upload(file, FileType.Audio);
		public async Task<byte[]?> GetImage(Guid id) => await Get(id, FileType.Image);
		public async Task<byte[]?> GetVideo(Guid id) => await Get(id, FileType.Video);
		public async Task<byte[]?> GetAudio(Guid id) => await Get(id, FileType.Audio);
	}
}

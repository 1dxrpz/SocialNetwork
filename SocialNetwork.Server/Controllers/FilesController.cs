using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SocialNetwork.Domain.Interfaces.Services;

namespace SocialNetwork.Server.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class FilesController : ControllerBase
	{
		IUploadService _uploadService;

		public FilesController(
			IUploadService uploadService)
		{
			_uploadService = uploadService;
		}
		[HttpPost("uploadimage")]
		public async Task<IActionResult> UploadImage(IFormFile image)
		{
			Guid id = await _uploadService.UploadImage(image);
			return Ok(id);
		}
		[HttpGet("getimage")]
		public async Task<IActionResult> GetImage(Guid id)
		{
			var image = await _uploadService.GetImage(id);
			if (image == null)
				return NotFound("File not found.");
			return File(image, "image/jpeg");
		}
		[HttpPost("uploadvideo")]
		public async Task<IActionResult> UploadVideo(IFormFile video)
		{
			Guid id = await _uploadService.UploadVideo(video);
			return Ok(id);
		}
		[HttpGet("getvideo")]
		public async Task<IActionResult> GetVideo(Guid id)
		{
			var image = await _uploadService.GetVideo(id);
			if (image == null)
				return NotFound("File not found.");
			return File(image, "video/mp4");
		}

		[HttpPost("uploadaudio")]
		public async Task<IActionResult> UploadAudio(IFormFile audio)
		{
			Guid id = await _uploadService.UploadAudio(audio);
			return Ok(id);
		}
		[HttpGet("getaudio")]
		public async Task<IActionResult> GetdAudio(Guid id)
		{
			var image = await _uploadService.GetAudio(id);
			if (image == null)
				return NotFound("File not found.");
			return File(image, "audio/mp3");
		}
	}
}

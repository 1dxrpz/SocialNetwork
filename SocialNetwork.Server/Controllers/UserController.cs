using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SocialNetwork.Domain.Entity;
using SocialNetwork.Domain.Interfaces.Services;

namespace SocialNetwork.Server.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class UserController : ControllerBase
	{
		IUserService _userService;
		public UserController(IUserService userService)
		{
			_userService = userService;
		}
		[HttpGet("user")]
		public async Task<IActionResult> GetUserById(Guid id)
		{
			return Ok(await _userService.GetById(id));
		}
		[HttpPost("adduser")]
		public async Task<IActionResult> PostUser(User user)
		{
			await _userService.Create(user);
			return Ok("penis died");
		}
	}
}

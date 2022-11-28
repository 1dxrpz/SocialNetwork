using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SocialNetwork.Domain.Entity;
using SocialNetwork.Domain.Interfaces.Services;
using SocialNetwork.Domain.ViewModels;

namespace SocialNetwork.Server.Controllers
{
	//[Authorize]
	[Route("api/[controller]")]
	[ApiController]
	public class UserController : ControllerBase
	{
		IUserService _userService;

		public UserController(
			IUserService userService)
		{
			_userService = userService;
		}
		[HttpGet("userbyid")]
		public async Task<IActionResult> GetUserById(Guid id)
		{
			return Ok(await _userService.GetById(id));
		}
		[HttpGet("users")]
		public async Task<IActionResult> GetUsers()
		{
			return Ok(await _userService.GetAll());
		}
		//[HttpGet("changeprofile")]
		//public async Task<IActionResult> ChangeProfile(UserViewModel user)
		//{
		//	return Ok(await _userService.GetAll());
		//}
		[HttpPost("login")]
		[AllowAnonymous]
		public async Task<IActionResult> Login(UserViewModel model)
		{
			var responce = await _userService.AuthenticateUser(model);
			if (responce == null)
				return Unauthorized();
			var user = await _userService.Find(v => v.Login == model.Login && v.Password == model.Password);
			if (user == null)
				return BadRequest(new { message = "User not found" });
			return Ok(responce);
		}
		[HttpPost("register")]
		[AllowAnonymous]
		public async Task<IActionResult> Register(UserViewModel model)
		{
			var user = await _userService.Find(v => v.Login == model.Login && v.Password == model.Password);
			if (user != null)
				return BadRequest(new { message = "User already exists" });
			var responce = await _userService.RegisterUser(model);
			return Ok(responce);
		}
	}
}

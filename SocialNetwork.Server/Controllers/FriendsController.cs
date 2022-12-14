using Microsoft.AspNetCore.Mvc;
using SocialNetwork.Domain.Entity;
using SocialNetwork.Domain.Enums;
using SocialNetwork.Domain.Interfaces.Services;

namespace SocialNetwork.Server.Controllers
{
	//[Authorize]
	[Route("api/[controller]")]
	[ApiController]
	public class FriendsController : ControllerBase
	{
		IFriendService _friendService;
		IUserService _userService;

		public FriendsController(
			IFriendService friendService, IUserService userService)
		{
			_friendService = friendService;
			_userService = userService;
		}

		[HttpGet("friends")]
		public async Task<IActionResult> GetFriends(Guid userId)
		{
			var friends = await _friendService
				.FindAll(v => v.UserId == userId && v.RelationType == RelationType.ActualFriend);
			return Ok(friends);
		}
		[HttpGet("friendrequests")]
		public async Task<IActionResult> GetFriendRequests(Guid userId)
		{
			var requests = await _friendService
				.FindAll(v => v.UserId == userId && v.RelationType == RelationType.FriendRequest);
			return Ok(requests);
		}
		[HttpPost("addfriend")]
		public async Task<IActionResult> AddFriend(Guid userId, Guid friendId)
		{
			var friends = await _friendService.Find(v => v.UserId == userId && v.FriendId == friendId);
			if (friends != null)
				return Ok("Already sent request");

			friends = new Friend()
			{
				Id = new Guid(),
				UserId = userId,
				FriendId = friendId,
				RelationType = RelationType.FriendRequest,
			};

			await _friendService.Create(friends);

			return Ok(friends);
		}
		[HttpPost("setrequeststatus")]
		public async Task<IActionResult> SetFriendRequestStatus(Guid userId, Guid requestId, FriendRequestStatus status)
		{
			var request = await _friendService
				.Find(v => v.UserId == userId &&
				v.FriendId == requestId &&
				v.RelationType == RelationType.FriendRequest);

			if (request == null)
				return Ok("No incomming requests");

			if (status == FriendRequestStatus.Rejected)
			{
				await _friendService.Delete(request.Id);
				return Ok(status);
			}
			if (status == FriendRequestStatus.Accepted)
			{
				request.RelationType = RelationType.ActualFriend;
				await _friendService.Update(request);
				return Ok(status);
			}
			return Ok(request);
		}
	}
}

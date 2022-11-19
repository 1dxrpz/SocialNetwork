using SocialNetwork.Domain.Enums;
using SocialNetwork.Domain.Interfaces;

namespace SocialNetwork.Domain.Entity
{
	public class Friend : IEntity
	{
		public Guid Id { get; set; }
		public Guid UserId { get; set; }
		public Guid FriendId { get; set; }
		public RelationType RelationType { get; set; }
	}
}

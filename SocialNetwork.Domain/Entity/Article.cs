using SocialNetwork.Domain.Interfaces;

namespace SocialNetwork.Domain.Entity
{
	public class Article : IEntity
	{
		public Guid Id { get; set; }
		public int AuthorId { get; set; }
		public string Title { get; set; }
		public DateTime Created { get; set; }
		public DateTime Updated { get; set; }
		public string Content { get; set; }
	}
}

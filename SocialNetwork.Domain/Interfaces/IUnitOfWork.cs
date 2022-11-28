using SocialNetwork.Domain.Entity;

namespace SocialNetwork.Domain.Interfaces
{
	public interface IUnitOfWork
	{
		public IRepository<User> UserRepository { get; }
		public IRepository<Friend> FriendRepository { get; }
		public IRepository<Article> ArticleRepository { get; }
	}
}

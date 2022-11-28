using SocialNetwork.Domain.Entity;
using SocialNetwork.Domain.Interfaces;
using SocialNetwork.Infrastructure.Data.Contexts;
using SocialNetwork.Infrastructure.Data.Repositories;

namespace SocialNetwork.Infrastructure.Data
{
	public class UnitOfWork : IUnitOfWork, IDisposable
	{
		readonly ApplicationContext _db;
		Repository<User> _userRepository;
		Repository<Friend> _friendRepository;
		Repository<Article> _articleRepository;

		public IRepository<User> UserRepository
		{
			get => _userRepository ??= new Repository<User>(_db);
		}
		public IRepository<Friend> FriendRepository
		{
			get => _friendRepository ??= new Repository<Friend>(_db);
		}
		public IRepository<Article> ArticleRepository
		{
			get => _articleRepository ??= new Repository<Article>(_db);
		}

		public UnitOfWork(ApplicationContext db)
		{
			_db = db;
		}

		private bool disposed = false;
		protected virtual void Dispose(bool disposing)
		{
			if (!disposed)
				if (disposing)
					_db.Dispose();
			disposed = true;
		}
		public void Dispose()
		{
			Dispose(true);
			GC.SuppressFinalize(this);
		}
	}
}
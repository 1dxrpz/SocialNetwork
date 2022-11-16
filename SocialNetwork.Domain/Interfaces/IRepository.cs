using System.Linq.Expressions;

namespace SocialNetwork.Domain.Interfaces
{
	public interface IRepository<T> : IDisposable
	{
		Task Create(T entity);
		Task Update(T entity);
		Task Delete(Guid id);
		Task<T> GetById(Guid id);
		Task<List<T>> GetAll();
		Task<T> Find(Expression<Func<T, bool>> expression);
		Task<List<T>> FindAll(Expression<Func<T, bool>> expression);
		Task Save();
	}
}
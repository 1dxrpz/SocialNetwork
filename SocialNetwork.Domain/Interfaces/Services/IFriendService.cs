using SocialNetwork.Domain.Entity;
using System.Linq.Expressions;

namespace SocialNetwork.Domain.Interfaces.Services
{
	public interface IFriendService
	{
		Task Create(Friend entity);
		Task Update(Friend entity);
		Task Delete(Guid id);
		Task<Friend> GetById(Guid id);
		Task<List<Friend>> GetAll();
		Task<List<Friend>> FindAll(Expression<Func<Friend, bool>> expression);
		Task<Friend> Find(Expression<Func<Friend, bool>> expression);
	}
}

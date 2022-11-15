using SocialNetwork.Domain.Entity;
using System.Linq.Expressions;

namespace SocialNetwork.Domain.Interfaces.Services
{
	public interface IUserService
	{
		Task Create(User entity);
		Task Update(User entity);
		Task Delete(Guid id);
		Task<User> GetById(Guid id);
		Task<List<User>> GetAll();
		Task<List<User>> Find(Expression<Func<User, bool>> expression);
	}
}

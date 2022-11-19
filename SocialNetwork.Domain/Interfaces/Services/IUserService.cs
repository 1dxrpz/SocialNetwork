using SocialNetwork.Domain.Entity;
using SocialNetwork.Domain.ViewModels;
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
		Task<List<User>> FindAll(Expression<Func<User, bool>> expression);
		Task<User> Find(Expression<Func<User, bool>> expression);
		Task<AuthenticateResponce> RegisterUser(UserViewModel user);
		Task<AuthenticateResponce> AuthenticateUser(UserViewModel user);
	}
}

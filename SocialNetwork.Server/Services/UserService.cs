using SocialNetwork.Domain.Entity;
using SocialNetwork.Domain.Interfaces;
using SocialNetwork.Domain.Interfaces.Services;
using System.Linq.Expressions;

namespace SocialNetwork.Server.Services
{
	public class UserService : IUserService
	{
		IUnitOfWork _unitOfWork;

		// TODO : model > viewmodel
		// TODO : unit tests
		// TODO : exceptions

		public UserService(IUnitOfWork unitOfWork)
		{
			_unitOfWork = unitOfWork;
		}
		public async Task Create(User model)
		{
			await _unitOfWork.UserRepository.Create(model);
			await _unitOfWork.UserRepository.Save();
		}
		public async Task Delete(Guid id)
		{
			await _unitOfWork.UserRepository.Delete(id);
		}
		public async Task Update(User model)
		{
			await _unitOfWork.UserRepository.Update(model);
		}
		public async Task<User> GetById(Guid id)
		{
			return await _unitOfWork.UserRepository.GetById(id);
		}
		public async Task<List<User>> GetAll()
		{
			return await _unitOfWork.UserRepository.GetAll();
		}
		public async Task<List<User>> Find(Expression<Func<User, bool>> expression)
		{
			return await _unitOfWork.UserRepository.Find(expression);
		}
	}
}

using AutoMapper;
using SocialNetwork.Domain.Entity;
using SocialNetwork.Domain.Interfaces;
using SocialNetwork.Domain.Interfaces.Services;
using System.Linq.Expressions;

namespace SocialNetwork.Server.Services
{
	public class FriendService : IFriendService
	{
		IUnitOfWork _unitOfWork;
		IMapper _mapper;
		IConfiguration _configuration;

		public FriendService(
			IUnitOfWork unitOfWork,
			IMapper mapper,
			IConfiguration configuration)
		{
			_unitOfWork = unitOfWork;
			_mapper = mapper;
			_configuration = configuration;
		}

		public async Task Create(Friend entity)
		{
			await _unitOfWork.FriendRepository.Create(entity);
			await _unitOfWork.FriendRepository.Save();
		}
		public async Task Delete(Guid id)
		{
			await _unitOfWork.FriendRepository.Delete(id);
			await _unitOfWork.FriendRepository.Save();
		}
		public async Task<Friend> Find(Expression<Func<Friend, bool>> expression)
		{
			return await _unitOfWork.FriendRepository.Find(expression);
		}
		public async Task<List<Friend>> FindAll(Expression<Func<Friend, bool>> expression)
		{
			return await _unitOfWork.FriendRepository.FindAll(expression);
		}
		public async Task<List<Friend>> GetAll()
		{
			return await _unitOfWork.FriendRepository.GetAll();
		}
		public async Task<Friend> GetById(Guid id)
		{
			return await _unitOfWork.FriendRepository.GetById(id);
		}
		public async Task Update(Friend entity)
		{
			await _unitOfWork.FriendRepository.Update(entity);
			await _unitOfWork.FriendRepository.Save();
		}
	}
}

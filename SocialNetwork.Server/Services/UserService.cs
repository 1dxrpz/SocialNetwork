using AutoMapper;
using Microsoft.IdentityModel.Tokens;
using SocialNetwork.Domain.Entity;
using SocialNetwork.Domain.Interfaces;
using SocialNetwork.Domain.Interfaces.Services;
using SocialNetwork.Domain.ViewModels;
using System.IdentityModel.Tokens.Jwt;
using System.Linq.Expressions;
using System.Security.Claims;
using System.Text;

namespace SocialNetwork.Server.Services
{
	public class UserService : IUserService
	{
		IUnitOfWork _unitOfWork;
		IMapper _mapper;
		IConfiguration _configuration;

		public UserService(
			IUnitOfWork unitOfWork,
			IMapper mapper,
			IConfiguration configuration)
		{
			_unitOfWork = unitOfWork;
			_mapper = mapper;
			_configuration = configuration;
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
			await _unitOfWork.UserRepository.Save();
		}
		public async Task<User> GetById(Guid id)
		{
			return await _unitOfWork.UserRepository.GetById(id);
		}
		public async Task<List<User>> GetAll()
		{
			return await _unitOfWork.UserRepository.GetAll();
		}
		public async Task<User> Find(Expression<Func<User, bool>> expression)
		{
			return await _unitOfWork.UserRepository.Find(expression);
		}
		public async Task<List<User>> FindAll(Expression<Func<User, bool>> expression)
		{
			return await _unitOfWork.UserRepository.FindAll(expression);
		}
		public async Task<AuthenticateResponce> RegisterUser(UserViewModel viewModel)
		{
			var user = await Find(v => v.Login == viewModel.Login);

			if (user != null)
				return null;

			user = _mapper.Map<User>(viewModel);
			await Create(user);
			var token = await Authenticate(user.Login, user.Password);
			return new AuthenticateResponce(user, token);
		}
		public async Task<AuthenticateResponce> AuthenticateUser(UserViewModel viewModel)
		{
			var user = await Find(v => v.Login == viewModel.Login);
			if (user == null)
				return null;
			user = _mapper.Map<User>(viewModel);
			var token = await Authenticate(user.Login, user.Password);
			return new AuthenticateResponce(user, token);
		}
		async private Task<string> Authenticate(string login, string password)
		{
			var user = await Find(v => v.Login == login && v.Password == password);
			if (user == null)
				return null;

			var key = Encoding.ASCII.GetBytes(_configuration["TokenSecret"]);
			var claims = new List<Claim>()
			{
				new Claim(ClaimTypes.Name, user.Login)
			};
			var creds = new SigningCredentials(new SymmetricSecurityKey(key),
					SecurityAlgorithms.HmacSha256Signature);
			
			var token = new JwtSecurityToken(
				claims: claims,
				expires: DateTime.UtcNow.AddHours(1),
				signingCredentials: creds);

			return new JwtSecurityTokenHandler().WriteToken(token);
		}
	}
}

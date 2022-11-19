using AutoMapper;
using SocialNetwork.Domain.Entity;
using SocialNetwork.Domain.ViewModels;

namespace SocialNetwork.Infrastructure.Data.MappingProfiles
{
	public class AppMappingProfile : Profile
	{
		public AppMappingProfile()
		{
			CreateMap<UserViewModel, User>();
		}
	}
}

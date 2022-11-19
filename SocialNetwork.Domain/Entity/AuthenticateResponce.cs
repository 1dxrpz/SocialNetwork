namespace SocialNetwork.Domain.Entity
{
	public class AuthenticateResponce
	{
		public Guid Id { get; set; }
		public Guid AvatarID { get; set; }
		public string Name { get; set; }
		public string Password { get; set; }
		public string Login { get; set; }
		public string Email { get; set; }
		public string Token { get; set; }
		public AuthenticateResponce(User user, string token)
		{
			Id = user.Id;
			AvatarID = user.AvatarID;
			Name = user.Name;
			Password = user.Password;
			Login = user.Login;
			Email = user.Email;
			Token = token;
		}
		
	}
}

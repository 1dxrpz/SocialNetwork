namespace SocialNetwork.Domain.ViewModels
{
	public class ArticleViewModel
	{
		public int AuthorId { get; set; }
		public string Title { get; set; }
		public DateTime Created { get; set; }
		public DateTime Updated { get; set; }
		public string Content { get; set; }
	}
}

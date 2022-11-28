using SocialNetwork.Domain.Entity;
using System.Linq.Expressions;

namespace SocialNetwork.Domain.Interfaces.Services
{
	public interface IArticleService
	{
		Task Create(Article entity);
		Task Update(Article entity);
		Task Delete(Guid id);
		Task<Article> GetById(Guid id);
		Task<List<Article>> GetAll();
		Task<List<Article>> FindAll(Expression<Func<Article, bool>> expression);
		Task<Article> Find(Expression<Func<Article, bool>> expression);
	}
}

using Microsoft.EntityFrameworkCore;
using SocialNetwork.Domain.Interfaces;
using SocialNetwork.Infrastructure.Data.Contexts;
using System.Linq.Expressions;

namespace SocialNetwork.Infrastructure.Data.Repositories
{
	public class Repository<T> : IRepository<T>, IDisposable where T : class, IEntity
	{
		readonly ApplicationContext _db;
		DbSet<T> _table;
		public Repository(ApplicationContext context)
		{
			_db = context;
			_table = _db.Set<T>();
		}
		public async Task Create(T entity) =>
			await _table.AddAsync(entity);
		public async Task Delete(Guid id)
		{
			var entity = await _table.FirstOrDefaultAsync(v => v.Id == id);
			_table.Attach(entity);
			_table.Remove(entity);
			await Save();
		}
		public async Task<List<T>> FindAll(Expression<Func<T, bool>> expression) =>
			await _table
				.AsQueryable()
				.Where(expression)
				.ToListAsync();
		public async Task<T> Find(Expression<Func<T, bool>> expression) =>
			await _table
				.AsQueryable()
				.Where(expression)
				.FirstOrDefaultAsync();
		public async Task<List<T>> GetAll() => 
			await _table
				.AsQueryable()
				.ToListAsync();
		public async Task<T> GetById(Guid id) =>
			await _table.FirstOrDefaultAsync(v => v.Id == id);
		public async Task Update(T entity)
		{
			_table.Attach(entity);
			_db.Entry(entity).State = EntityState.Modified;
			await Save();
		}
		public async Task Save() => await _db.SaveChangesAsync();

		private bool disposed = false;
		protected virtual void Dispose(bool disposing)
		{
			if (!disposed)
				if (disposing)
					_db.Dispose();
			disposed = true;
		}
		public void Dispose()
		{
			Dispose(true);
			GC.SuppressFinalize(this);
		}
	}
}

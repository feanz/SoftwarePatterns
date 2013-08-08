using System;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Linq.Expressions;

namespace SoftwarePatterns.Core.Repository
{
	public class EfRepository<T> : IRepository<T> where T : class
	{
		private readonly DbContext _dbContext;
		private readonly DbSet<T> _dbSet;

		public EfRepository(DbContext dbContext)
		{
			if (dbContext == null) throw new ArgumentNullException("dbContext");
			_dbContext = dbContext;
			_dbSet = _dbContext.Set<T>();
		}

		public virtual void Add(T entity)
		{
			DbEntityEntry dbEntityEntry = _dbContext.Entry(entity);
			if (dbEntityEntry.State != EntityState.Detached)
			{
				dbEntityEntry.State = EntityState.Added;
			}
			else
			{
				_dbSet.Add(entity);
			}
		}

		public virtual void Delete(T entity)
		{
			DbEntityEntry dbEntityEntry = _dbContext.Entry(entity);
			if (dbEntityEntry.State != EntityState.Deleted)
			{
				dbEntityEntry.State = EntityState.Deleted;
			}
			else
			{
				_dbSet.Attach(entity);
				_dbSet.Remove(entity);
			}
		}

		public virtual void Delete(int id)
		{
			var entity = GetById(id);
			if (entity == null) return; // not found; assume already deleted.
			Delete(entity);
		}

		public virtual T Get(Expression<Func<T, bool>> predicate)
		{
			return _dbSet.FirstOrDefault(predicate);
		}

		public virtual IQueryable<T> GetAll()
		{
			return _dbSet;
		}

		public virtual T GetById(int id)
		{
			return _dbSet.Find(id);
		}

		public virtual void Update(T entity)
		{
			DbEntityEntry dbEntityEntry = _dbContext.Entry(entity);
			if (dbEntityEntry.State == EntityState.Detached)
			{
				_dbSet.Attach(entity);
			}
			dbEntityEntry.State = EntityState.Modified;
		}
	}

	public interface ICacheable
	{
		 string CacheKey { get; set; }
	}
}
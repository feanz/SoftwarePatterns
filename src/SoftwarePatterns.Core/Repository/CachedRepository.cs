using System;
using System.Linq;
using System.Linq.Expressions;

namespace SoftwarePatterns.Core.Repository
{
	/// <summary>
	///     Here we use composition instead of inheritance here sp the CachedRepository implements IRepository and takes an
	///     IRepository as a constructor param
	///     just to avoid a big long chain where an ProjectRepository implementing IProjectRepository  would inherit from a
	///     CachedProjectRepository
	///     which inherits from a CahcedRepository which inherits form a ProjectEFRepository which inherits from a EfRepsoitry
	///     arrrrrrrrrrrrrrrrrrrrrrrhhhhhhhhhhhhhh
	///  This generic type cache repository requires that T implement ICacheable just so we can extract keys, chance are you will always implement a type specific cache repository
	/// </summary>
	/// <typeparam name="T"></typeparam>
	public class CachedRepository<T> : IRepository<T> where T : class, ICacheable
	{
		private readonly ICacheStorage _cache;
		private readonly IRepository<T> _repository;

		public CachedRepository(IRepository<T> repository, ICacheStorage cache)
		{
			_repository = repository;
			_cache = cache;
		}

		public virtual void Add(T entity)
		{
			_repository.Add(entity);
		}

		public virtual void Delete(T entity)
		{
			_repository.Delete(entity);
			_cache.Clear(entity.CacheKey);
		}

		public virtual void Delete(int id)
		{
			var key = CreateCacheKey(id);
			_repository.Delete(id);
			_cache.Clear(key);
		}

		public virtual T Get(Expression<Func<T, bool>> predicate)
		{
			return _repository.Get(predicate);
		}

		public virtual IQueryable<T> GetAll()
		{
			return _repository.GetAll();
		}

		public virtual T GetById(int id)
		{
			var cacheKey = CreateCacheKey(id);
			var entity = _cache.Get<T>(cacheKey);

			if (entity == null)
			{
				entity = _repository.GetById(id);
				_cache.Set(cacheKey, entity);
			}
			return entity;
		}

		public virtual void Update(T entity)
		{
			_repository.Update(entity);
			_cache.Set(entity.CacheKey, entity);
		}

		protected static string CreateCacheKey(params object[] param)
		{
			var paramKey = string.Join("-", param.ToString());

			if (string.IsNullOrEmpty(paramKey) || string.IsNullOrWhiteSpace(paramKey)) throw new ArgumentException("Parameter provided could not be used to generate cache key");

			return string.Format("{0}-{1}", typeof (T).Name.ToLowerInvariant(), paramKey);
		}
	}
}
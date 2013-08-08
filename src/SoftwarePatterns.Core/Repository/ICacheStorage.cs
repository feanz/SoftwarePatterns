using System.Runtime.Caching;

namespace SoftwarePatterns.Core.Repository
{
	public interface ICacheStorage
	{
		T Get<T>(string key) where T : class;
		void Set<T>(string key, T entity);
		void Clear(string key);
	}

	public class MemoryCacheStorage : ICacheStorage
	{
		public T Get<T>(string key) where T : class
		{
			return MemoryCache.Default[key] as T;
		}

		public void Set<T>(string key, T entity)
		{
			var cacheItem = new CacheItem(key, entity);
			var policy = new CacheItemPolicy();
			MemoryCache.Default.Add(cacheItem, policy);
		}

		public void Clear(string key)
		{
			MemoryCache.Default.Remove(key);
		}
	}
}
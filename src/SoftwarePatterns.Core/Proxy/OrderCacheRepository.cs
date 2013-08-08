using System;
using System.Runtime.Caching;

namespace SoftwarePatterns.Core.Proxy
{
	public class OrderCacheRepository : OrderRepository
	{
		public override Order GetById(int id)
		{
			var cacheKey = CreateCacheKey<Order>(id);
			var entity = MemoryCache.Default[cacheKey] as Order;

			if (entity == null)
			{
				entity = base.GetById(id);
				var cacheItem = new CacheItem(cacheKey, entity);
				var policy = new CacheItemPolicy();
				MemoryCache.Default.Add(cacheItem, policy);
			}
			return entity;
		}

		private static string CreateCacheKey<T>(params object[] parms)
		{
			var paramKey = string.Join("-", parms.ToString());

			if(string.IsNullOrEmpty(paramKey) || string.IsNullOrWhiteSpace(paramKey))  throw new ArgumentException("Parameter provided could not be used to generate cache key");

			return string.Format("{0}-{1}", typeof (T).Name.ToLowerInvariant(), paramKey);
		}
	}
}
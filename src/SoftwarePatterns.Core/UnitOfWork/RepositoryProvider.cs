using System;
using System.Collections.Generic;
using System.Data.Entity;
using SoftwarePatterns.Core.Repository;

namespace SoftwarePatterns.Core.UnitOfWork
{
	/// <summary>
	///     Provides an IRepository{T} for a client request.
	/// </summary>
	/// <remarks>
	///     Caches repositories of a given type so that repositories are only created once per provider.
	///     Code Camper creates a new provider per client request.
	/// </remarks>
	public class RepositoryProvider : IRepositoryProvider
	{
		private readonly RepositoryFactories _repositoryFactories;

		public RepositoryProvider(RepositoryFactories repositoryFactories)
		{
			_repositoryFactories = repositoryFactories;
			_repositories = new Dictionary<Type, object>();
		}

		private Dictionary<Type, object> _repositories { get; set; }

		/// <summary>
		///     Get or create and cache repository using the factory method provided
		/// </summary>
		/// <typeparam name="T"></typeparam>
		/// <param name="factory"></param>
		/// <returns></returns>
		public T GetRepository<T>(Func<DbContext, object> factory = null) where T : class
		{
			object repoObj;
			_repositories.TryGetValue(typeof (T), out repoObj);
			if (repoObj != null)
			{
				return (T) repoObj;
			}

			return MakeRepository<T>(factory, DbContext);
		}

		/// <summary>
		///     Make a repository of type T with factory method provided or the default for factory
		/// </summary>
		private T MakeRepository<T>(Func<DbContext, object> factory, DbContext dbContext) where T : class
		{
			var f = factory ?? _repositoryFactories.GetRepositoryFactoryForEntityType<T>();
			if (f == null)
			{
				throw new NotImplementedException("No factory for repository type, " + typeof (T).FullName);
			}
			var repo = (T) f(dbContext);
			_repositories[typeof (T)] = repo;
			return repo;
		}

		public DbContext DbContext { get; set; }

		/// <summary>
		///     Get or create and cache repository for type T, If can't find repository in cache use the factory for T to create
		/// </summary>
		/// <typeparam name="T"></typeparam>
		/// <returns></returns>
		public IRepository<T> GetRepositoryForEntityType<T>() where T : class
		{
			return GetRepository<IRepository<T>>(_repositoryFactories.GetRepositoryFactoryForEntityType<T>());
		}

		/// <summary>
		///     Set the repository for type T that this provider should return.
		/// </summary>
		public void SetRepository<T>(T repository) where T : class
		{
			_repositories[typeof (T)] = repository;
		}
	}
}
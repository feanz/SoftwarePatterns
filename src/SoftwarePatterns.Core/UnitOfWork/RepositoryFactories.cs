using System;
using System.Collections.Generic;
using System.Data.Entity;
using SoftwarePatterns.Core.Repository;

namespace SoftwarePatterns.Core.UnitOfWork
{
	/// <summary>
	///     A single factory class that control instantiating repositories classes.  When using Ioc this should have singleton
	///     scope
	/// </summary>
	public class RepositoryFactories
	{
		private readonly IDictionary<Type, Func<DbContext, object>> _repositoryFactories;

		public RepositoryFactories()
		{
			_repositoryFactories = GetRepositoryFactories();
		}

		public RepositoryFactories(IDictionary<Type, Func<DbContext, object>> repositoryFactories)
		{
			_repositoryFactories = repositoryFactories;
		}

		/// <summary>
		///     Get factory method from store of factories
		/// </summary>
		/// <typeparam name="T"></typeparam>
		/// <returns></returns>
		public Func<DbContext, object> GetRepositoryFactory<T>()
		{
			Func<DbContext, object> factory;
			_repositoryFactories.TryGetValue(typeof (T), out factory);
			return factory;
		}

		/// <summary>
		///     Get the factory func for this T or use default if one has not been provided
		/// </summary>
		/// <typeparam name="T"></typeparam>
		/// <returns></returns>
		public Func<DbContext, object> GetRepositoryFactoryForEntityType<T>() where T : class
		{
			return GetRepositoryFactory<T>() ?? DefaultEntityRepositoryFactory<T>();
		}

		/// <summary>
		///     Default factory method to build repository
		/// </summary>
		/// <typeparam name="T"></typeparam>
		/// <returns></returns>
		private static Func<DbContext, object> DefaultEntityRepositoryFactory<T>() where T : class
		{
			return dbContext => new EfRepository<T>(dbContext);
		}

		private static IDictionary<Type, Func<DbContext, object>> GetRepositoryFactories()
		{
			//We don't need create any factories to at the moment as we are only using default repositories for our type
			//This is where you could specify a set of factories to use this would break open closed however it would be better to reflect over the assembly and 
			//get any IRepositoryFactories that would return a Func<DbContext,object> .
			return new Dictionary<Type, Func<DbContext, object>>();
		}
	}
}
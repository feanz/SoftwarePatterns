using System;
using System.Data.Entity;
using SoftwarePatterns.Core.Repository;

namespace SoftwarePatterns.Core.UnitOfWork
{
	public interface IRepositoryProvider
	{
		DbContext DbContext { get; set; }
		T GetRepository<T>(Func<DbContext, object> factory = null) where T : class;
		IRepository<T> GetRepositoryForEntityType<T>() where T : class;
		void SetRepository<T>(T repository) where T : class;
	}
}
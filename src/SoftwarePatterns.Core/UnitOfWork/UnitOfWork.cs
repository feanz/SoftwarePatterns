using System;
using SoftwarePatterns.Core.Repository;

namespace SoftwarePatterns.Core.UnitOfWork
{
	public class UnitOfWork : IUnitOfWork
	{
		private ExampleDbContext _dbContext;

		public UnitOfWork(IRepositoryProvider repositoryProvider)
		{
			CreateDbContext();

			RepositoryProvider = repositoryProvider;
			RepositoryProvider.DbContext = _dbContext;
		}

		protected IRepositoryProvider RepositoryProvider { get; set; }

		protected virtual void Dispose(bool disposing)
		{
			if (disposing)
			{
				if (_dbContext != null)
				{
					_dbContext.Dispose();
				}
			}
		}

		private void CreateDbContext()
		{
			_dbContext = new ExampleDbContext();

			//add db context configuration here
		}

		private T GetRepo<T>() where T : class
		{
			return RepositoryProvider.GetRepository<T>();
		}

		private IRepository<T> GetStandardRepo<T>() where T : class
		{
			return RepositoryProvider.GetRepositoryForEntityType<T>();
		}

		public void Commit()
		{
			_dbContext.SaveChanges();
		}

		public void Dispose()
		{
			Dispose(true);
			GC.SuppressFinalize(this);
		}

		public IRepository<Project> Projects
		{
			get { return GetStandardRepo<Project>(); }
		}

		public IRepository<WorkItem> WorkItems
		{
			get { return GetStandardRepo<WorkItem>(); }
		}
	}
}
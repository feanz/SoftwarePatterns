using System;
using SoftwarePatterns.Core.Repository;

namespace SoftwarePatterns.Core.UnitOfWork
{
	public interface IUnitOfWork : IDisposable
	{
		IRepository<Project> Projects { get; }
		IRepository<WorkItem> WorkItems { get; }
		void Commit();
	}
}
using System;
using System.Linq;
using System.Linq.Expressions;

namespace SoftwarePatterns.Core.Repository
{
	public interface IRepository<T>
	{
		T GetById(int id);
		IQueryable<T> GetAll();
		T Get(Expression<Func<T, bool>> predicate);
		void Add(T entity);
		void Update(T entity);
		void Delete(T entity);
		void Delete(int id);
	}
}
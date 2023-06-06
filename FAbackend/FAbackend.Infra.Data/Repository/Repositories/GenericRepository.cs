using FAbackend.Infra.Data.Context;
using FAbackend.Infra.Data.Repository.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace FAbackend.Infra.Data.Repository.Repositories
{
	public class GenericRepository<T> : IGenericRepository<T> where T : class
	{
		private readonly ApplicationContext _context;

		public GenericRepository(ApplicationContext context)
		{
			_context = context;
		}

		public T Get(int id)
		{
			return _context.Set<T>().Find(id);
		}

		public void Add(T entity)
		{
			_context.Set<T>().Add(entity);
		}

		public void Update(T entity)
		{
			_context.Set<T>().Attach(entity);
			_context.Entry(entity).State = EntityState.Modified;
		}

		public void Remove(T entity)
		{
			_context.Set<T>().Remove(entity);
		}
	}
}

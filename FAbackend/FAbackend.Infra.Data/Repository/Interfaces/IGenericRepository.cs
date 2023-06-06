namespace FAbackend.Infra.Data.Repository.Interfaces
{
	public interface IGenericRepository<T> where T : class
	{
		T Get(int id);
		void Add(T entity);
		void Update(T entity);
		void Remove(T entity);
	}
}

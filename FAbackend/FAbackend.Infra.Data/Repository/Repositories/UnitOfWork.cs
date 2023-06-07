using FAbackend.Infra.Data.Context;
using FAbackend.Infra.Data.Repository.Interfaces;

namespace FAbackend.Infra.Data.Repository.Repositories
{
	public class UnitOfWork : IUnitOfWork
	{
		private readonly ApplicationContext _context;
		private readonly ICreatorRepository _creatorRepository;
		private readonly IAffiliatedRepository _affiliatedRepository;

		public UnitOfWork(ApplicationContext context)
		{
			_context = context;
			_creatorRepository = new CreatorRepository(context);
			_affiliatedRepository = new AffiliatedRepository(context);
		}

		public ICreatorRepository CreatorRepository { get { return _creatorRepository; } }
		public IAffiliatedRepository AffiliatedRepository { get { return _affiliatedRepository; } }

		public void Save()
		{
			_context.SaveChanges();
		}

		public void Dispose()
		{
			_context.Dispose();
			GC.SuppressFinalize(this);
		}
	}
}

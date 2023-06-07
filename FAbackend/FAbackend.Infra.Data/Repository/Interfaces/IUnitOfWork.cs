namespace FAbackend.Infra.Data.Repository.Interfaces
{
	public interface IUnitOfWork : IDisposable
	{
		ICreatorRepository CreatorRepository { get; }
		IAffiliatedRepository AffiliatedRepository { get; }
		void Save();
	}
}

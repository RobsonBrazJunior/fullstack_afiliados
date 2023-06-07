using FAbackend.Application.Interfaces;
using FAbackend.Entities.Models;
using FAbackend.Infra.Data.Repository.Interfaces;

namespace FAbackend.Application.Services
{
	internal class AffiliatedService : IAffiliatedService
	{
		private readonly IAffiliatedRepository _affiliatedRepository;

		public AffiliatedService(IAffiliatedRepository affiliatedRepository)
		{
			_affiliatedRepository = affiliatedRepository;
		}

		public Affiliated Get(int id) => _affiliatedRepository.Get(id);

		public void Add(Affiliated affiliated)
		{
			_affiliatedRepository.Add(affiliated);
		}

		public void Update(Affiliated affiliated)
		{
			_affiliatedRepository.Update(affiliated);
		}

		public void Remove(Affiliated affiliated)
		{
			_affiliatedRepository.Remove(affiliated);
		}
	}
}

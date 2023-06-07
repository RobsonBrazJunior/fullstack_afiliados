using FAbackend.Application.Interfaces;
using FAbackend.Domain.Models;
using FAbackend.Infra.Data.Repository.Interfaces;

namespace FAbackend.Application.Services
{
	public class CreatorService : ICreatorService
	{
		private readonly ICreatorRepository _creatorRepository;

		public CreatorService(ICreatorRepository creatorRepository)
		{
			creatorRepository = _creatorRepository;
		}

		public Creator Get(int id) => _creatorRepository.Get(id);

		public void Add(Creator creator)
		{
			_creatorRepository.Add(creator);
		}

		public void Update(Creator creator)
		{
			_creatorRepository.Update(creator);
		}

		public void Remove(Creator creator)
		{
			_creatorRepository.Remove(creator);
		}
	}
}

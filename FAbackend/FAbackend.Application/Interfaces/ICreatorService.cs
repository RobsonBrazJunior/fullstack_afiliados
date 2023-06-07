using FAbackend.Domain.Entities;

namespace FAbackend.Application.Interfaces
{
	public interface ICreatorService
	{
		Creator Get(int id);
		void Add(Creator creator);
		void Update(Creator creator);
		void Remove(Creator creator);
	}
}

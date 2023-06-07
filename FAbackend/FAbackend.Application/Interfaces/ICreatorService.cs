using FAbackend.Domain.Models;

namespace FAbackend.Application.Interfaces
{
	public interface ICreatorService
	{
		CreatorModel Get(int id);
		void Add(CreatorModel creator);
		void Update(CreatorModel creator);
		void Remove(CreatorModel creator);
	}
}

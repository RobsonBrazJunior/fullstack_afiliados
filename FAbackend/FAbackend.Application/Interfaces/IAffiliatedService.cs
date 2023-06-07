using FAbackend.Entities.Models;

namespace FAbackend.Application.Interfaces
{
	public interface IAffiliatedService
	{
		Affiliated Get(int id);
		void Add(Affiliated affiliated);
		void Update(Affiliated affiliated);
		void Remove(Affiliated affiliated);
	}
}

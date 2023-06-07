using FAbackend.Domain.Models;

namespace FAbackend.Application.Interfaces
{
	public interface IAffiliatedService
	{
		AffiliatedModel Get(int id);
		void Add(AffiliatedModel affiliated);
		void Update(AffiliatedModel affiliated);
		void Remove(AffiliatedModel affiliated);
	}
}

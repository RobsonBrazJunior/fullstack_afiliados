using FAbackend.Application.Interfaces;
using FAbackend.Domain.Models;
using Microsoft.AspNetCore.Mvc;

namespace FAbackend.WebApi.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class AffiliatedController : ControllerBase
	{
		private readonly IAffiliatedService _affiliatedService;

		public AffiliatedController(IAffiliatedService affiliatedService)
		{
			_affiliatedService = affiliatedService;
		}

		[HttpGet("{id:int}")]
		public AffiliatedModel Get(int id)
		{
			return _affiliatedService.Get(id);
		}

		[HttpPost("add")]
		public void Add([FromBody] AffiliatedModel affiliatedModel)
		{
			_affiliatedService.Add(affiliatedModel);
		}

		[HttpPost("update")]
		public void Update([FromBody] AffiliatedModel affiliatedModel)
		{
			_affiliatedService.Update(affiliatedModel);
		}

		[HttpPost("remove")]
		public void Remove([FromBody] AffiliatedModel affiliatedModel)
		{
			_affiliatedService.Remove(affiliatedModel);
		}
	}
}

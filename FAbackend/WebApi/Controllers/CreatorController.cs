using FAbackend.Application.Interfaces;
using FAbackend.Domain.Models;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class CreatorController : ControllerBase
	{
		private readonly ICreatorService _creatorService;

		public CreatorController(ICreatorService creatorService)
		{
			_creatorService = creatorService;
		}

		[HttpGet("{id:int}")]
		public CreatorModel Get(int id)
		{
			return _creatorService.Get(id);
		}

		[HttpPost("add")]
		public void Add([FromBody] CreatorModel creatorModel)
		{
			_creatorService.Add(creatorModel);
		}

		[HttpPost("update")]
		public void Update([FromBody] CreatorModel creatorModel)
		{
			_creatorService.Update(creatorModel);
		}

		[HttpPost("remove")]
		public void Remove([FromBody] CreatorModel creatorModel)
		{
			_creatorService.Remove(creatorModel);
		}
	}
}

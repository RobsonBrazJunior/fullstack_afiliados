using AutoMapper;
using FAbackend.Domain.Entities;
using FAbackend.Domain.Models;

namespace FAbackend.Application.AutoMapper
{
	public class CreatorModelToEntityMappingProfile : Profile
	{
		public CreatorModelToEntityMappingProfile()
		{
			CreateMap<CreatorModel, Creator>()
				.ForMember(dest => dest.Affiliateds, options => options.Ignore());
		}
	}
}

using AutoMapper;
using FAbackend.Domain.Entities;
using FAbackend.Domain.Models;

namespace FAbackend.Application.AutoMapper
{
	public class AffiliatedEntityModelMappingProfile : Profile
	{
		public AffiliatedEntityModelMappingProfile()
		{
			CreateMap<Affiliated, AffiliatedModel>()
				.ForSourceMember(source => source.Creator, options => options.DoNotValidate())
					.ReverseMap()
					.ForMember(dest => dest.Creator, options => options.Ignore());
		}
	}
}

using AutoMapper;
using FAbackend.Domain.Entities;
using FAbackend.Domain.Models;

namespace FAbackend.Application.AutoMapper
{
	public class CreatorEntityToModelMappingProfile : Profile
	{
		public CreatorEntityToModelMappingProfile()
		{
			CreateMap<Creator, CreatorModel>()
				.ForSourceMember(source => source.Affiliateds, options => options.DoNotValidate());
		}
	}
}

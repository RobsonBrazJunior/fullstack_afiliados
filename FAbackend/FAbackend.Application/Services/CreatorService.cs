using AutoMapper;
using FAbackend.Application.Interfaces;
using FAbackend.Domain.Entities;
using FAbackend.Domain.Models;
using FAbackend.Infra.Data.Repository.Interfaces;
using FluentValidation;

namespace FAbackend.Application.Services
{
	public class CreatorService : ICreatorService
	{
		private readonly IMapper _mapper;
		private readonly IValidator<CreatorModel> _validator;
		private readonly ICreatorRepository _creatorRepository;

		public CreatorService(IMapper mapper,
							  IValidator<CreatorModel> validator,
							  ICreatorRepository creatorRepository)
		{
			_mapper = mapper;
			_validator = validator;
			_creatorRepository = creatorRepository;
		}

		public CreatorModel Get(int id)
		{
			return _mapper.Map<CreatorModel>(_creatorRepository.Get(id));
		}

		public void Add(CreatorModel creator)
		{
			_validator.ValidateAndThrow(creator);
			_creatorRepository.Add(_mapper.Map<Creator>(creator));
		}

		public void Update(CreatorModel creator)
		{
			_validator.ValidateAndThrow(creator);
			_creatorRepository.Update(_mapper.Map<Creator>(creator));
		}

		public void Remove(CreatorModel creator)
		{
			_creatorRepository.Remove(_mapper.Map<Creator>(creator));
		}
	}
}

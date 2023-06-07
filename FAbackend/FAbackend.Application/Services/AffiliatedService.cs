using AutoMapper;
using FAbackend.Application.Interfaces;
using FAbackend.Domain.Entities;
using FAbackend.Domain.Models;
using FAbackend.Infra.Data.Repository.Interfaces;
using FluentValidation;

namespace FAbackend.Application.Services
{
	internal class AffiliatedService : IAffiliatedService
	{
		private readonly IMapper _mapper;
		private readonly IValidator<AffiliatedModel> _validator;
		private readonly IAffiliatedRepository _affiliatedRepository;

		public AffiliatedService(IMapper mapper,
								 IValidator<AffiliatedModel> validator,
								 IAffiliatedRepository affiliatedRepository)
		{
			_mapper = mapper;
			_validator = validator;
			_affiliatedRepository = affiliatedRepository;
		}

		public AffiliatedModel Get(int id)
		{
			return _mapper.Map<AffiliatedModel>(_affiliatedRepository.Get(id));
		}

		public void Add(AffiliatedModel affiliated)
		{
			_validator.ValidateAndThrow(affiliated);
			_affiliatedRepository.Add(_mapper.Map<Affiliated>(affiliated));
		}

		public void Update(AffiliatedModel affiliated)
		{
			_validator.ValidateAndThrow(affiliated);
			_affiliatedRepository.Update(_mapper.Map<Affiliated>(affiliated));
		}

		public void Remove(AffiliatedModel affiliated)
		{
			_affiliatedRepository.Remove(_mapper.Map<Affiliated>(affiliated));
		}
	}
}

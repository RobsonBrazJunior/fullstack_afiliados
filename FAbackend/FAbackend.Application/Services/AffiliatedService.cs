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
		private readonly IUnitOfWork _unitOfWork;

		public AffiliatedService(IMapper mapper,
								 IValidator<AffiliatedModel> validator,
								 IUnitOfWork unitOfWork)
		{
			_mapper = mapper;
			_validator = validator;
			_unitOfWork = unitOfWork;
		}

		public AffiliatedModel Get(int id)
		{
			return _mapper.Map<AffiliatedModel>(_unitOfWork.AffiliatedRepository.Get(id));
		}

		public void Add(AffiliatedModel affiliated)
		{
			_validator.ValidateAndThrow(affiliated);
			_unitOfWork.AffiliatedRepository.Add(_mapper.Map<Affiliated>(affiliated));
		}

		public void Update(AffiliatedModel affiliated)
		{
			_validator.ValidateAndThrow(affiliated);
			_unitOfWork.AffiliatedRepository.Update(_mapper.Map<Affiliated>(affiliated));
		}

		public void Remove(AffiliatedModel affiliated)
		{
			_unitOfWork.AffiliatedRepository.Remove(_mapper.Map<Affiliated>(affiliated));
		}
	}
}

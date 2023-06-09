﻿using AutoMapper;
using FAbackend.Application.Interfaces;
using FAbackend.Domain.Entities;
using FAbackend.Domain.Models;
using FAbackend.Infra.Data.Repository.Interfaces;
using FluentValidation;
using FluentValidation.Results;

namespace FAbackend.Application.Services
{
	public class CreatorService : ICreatorService
	{
		private readonly IMapper _mapper;
		private readonly IValidator<CreatorModel> _validator;
		private readonly IUnitOfWork _unitOfWork;
		public ValidationResult ValidationResult { get; protected set; }

		public CreatorService(IMapper mapper,
							  IValidator<CreatorModel> validator,
							  IUnitOfWork unitOfWork)
		{
			_mapper = mapper;
			_validator = validator;
			_unitOfWork = unitOfWork;
		}

		public CreatorModel Get(int id)
		{
			return _mapper.Map<CreatorModel>(_unitOfWork.CreatorRepository.Get(id));
		}

		public void Add(CreatorModel creator)
		{
			ValidationResult = _validator.Validate(creator);
			if (!ValidationResult.IsValid) return;
			_unitOfWork.CreatorRepository.Add(_mapper.Map<Creator>(creator));
			_unitOfWork.Save();
		}

		public void Update(CreatorModel creator)
		{
			ValidationResult = _validator.Validate(creator);
			if (!ValidationResult.IsValid) return;
			_unitOfWork.CreatorRepository.Update(_mapper.Map<Creator>(creator));
			_unitOfWork.Save();
		}

		public void Remove(CreatorModel creator)
		{
			_unitOfWork.CreatorRepository.Remove(_mapper.Map<Creator>(creator));
			_unitOfWork.Save();
		}
	}
}

using AutoMapper;
using FAbackend.Application.Services;
using FAbackend.Domain.Entities;
using FAbackend.Domain.Models;
using FAbackend.Domain.Validations;
using FAbackend.Infra.Data.Repository.Interfaces;
using FluentAssertions;
using Moq;

namespace FAbackend.Application.Tests.Services
{
	public class CreatorServiceTests
	{
		private readonly Mock<IMapper> _mockMapper;
		private readonly Mock<IUnitOfWork> _mockUnitOfWork;
		private readonly Mock<ICreatorRepository> _mockCreatorRepository;

		public CreatorServiceTests()
		{
			_mockMapper = new Mock<IMapper>();
			_mockUnitOfWork = new Mock<IUnitOfWork>();
			_mockCreatorRepository = new Mock<ICreatorRepository>();
		}

		[Fact]
		public void Add_MustSuccessfullyAddCreator()
		{
			//Arrange
			var validator = new CreatorModelValidation();
			var creator = new CreatorModel() { Id = 0, Name = "Fulano" };
			_mockUnitOfWork.Setup(x => x.CreatorRepository).Returns(_mockCreatorRepository.Object);
			var creatorService = new CreatorService(_mockMapper.Object, validator, _mockUnitOfWork.Object);

			//Act
			creatorService.Add(creator);

			//Assert
			_mockUnitOfWork.Verify(x => x.CreatorRepository.Add(_mockMapper.Object.Map<Creator>(creator)), Times.Once);
			_mockUnitOfWork.Verify(x => x.Save(), Times.Once);
			creatorService.ValidationResult.Errors.Should().HaveCount(0);
		}

		[Fact]
		public void Add_MustNotAddCreator()
		{
			//Arrange
			var validator = new CreatorModelValidation();
			var creator = new CreatorModel() { Name = "" };
			_mockUnitOfWork.Setup(x => x.CreatorRepository).Returns(_mockCreatorRepository.Object);
			var creatorService = new CreatorService(_mockMapper.Object, validator, _mockUnitOfWork.Object);

			//Act
			creatorService.Add(creator);

			//Assert
			_mockUnitOfWork.Verify(x => x.CreatorRepository.Add(_mockMapper.Object.Map<Creator>(creator)), Times.Never);
			_mockUnitOfWork.Verify(x => x.Save(), Times.Never);
			creatorService.ValidationResult.Errors.Should().HaveCountGreaterOrEqualTo(1);
			creatorService.ValidationResult.Errors.FirstOrDefault()?.ErrorMessage.Should().Be("Name must be filled in!");
		}
	}
}

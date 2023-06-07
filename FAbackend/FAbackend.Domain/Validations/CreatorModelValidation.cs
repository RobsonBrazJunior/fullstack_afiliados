using FAbackend.Domain.Models;
using FluentValidation;

namespace FAbackend.Domain.Validations
{
	public class CreatorModelValidation : AbstractValidator<CreatorModel>
	{
		public CreatorModelValidation()
		{
			RuleFor(x => x.Name)
				.NotNull().NotEmpty().WithMessage("Name must be filled in!");
		}
	}
}

using FAbackend.Domain.Models;
using FluentValidation;

namespace FAbackend.Domain.Validations
{
	public class AffiliatedValidation : AbstractValidator<AffiliatedModel>
	{
		public AffiliatedValidation()
		{
			RuleFor(x => x.Name)
				.NotNull().NotEmpty().WithMessage("Name must be filled in!");
		}
	}
}

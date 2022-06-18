using FluentValidation;

namespace DezContas.Domain.Entities.Validators
{
	public class AccountValidator : AbstractValidator<Account>
	{
		public AccountValidator()
		{
			RuleFor(x => x.Name).NotNull().NotEmpty().WithMessage("Name is required")
				.MinimumLength(3).WithMessage("Minimum length must be 3 characters")
				.MaximumLength(150).WithMessage("Maximum length must be 100 characters");

			RuleFor(x => x.Description).MaximumLength(500).WithMessage("Maximum length must be 50 characters");

			RuleFor(x => x.Type).NotNull().NotNull().WithMessage("Type is required");
		}
	}
}

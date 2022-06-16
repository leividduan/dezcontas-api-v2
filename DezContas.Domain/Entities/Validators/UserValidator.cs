using DezContas.Domain.Utils;
using FluentValidation;

namespace DezContas.Domain.Entities.Validators
{
	public class UserValidator : AbstractValidator<User>
	{
		public UserValidator()
		{
			RuleFor(x => x.Name).NotNull().NotEmpty().WithMessage("Name is required")
				.MinimumLength(3).WithMessage("Minimum length must be 3 characters")
				.MaximumLength(100).WithMessage("Maximum length must be 100 characters");

			RuleFor(x => x.AtSign).NotNull().NotNull().WithMessage("AtSign is required")
				.MinimumLength(3).WithMessage("Minimum length must be 3 characters")
				.MaximumLength(50).WithMessage("Maximum length must be 50 characters");

			RuleFor(x => x.Email).NotNull().NotNull().WithMessage("Email is required")
				.EmailAddress().WithMessage("A valid email is required");

			RuleFor(x => x.Password).NotNull().NotNull().WithMessage("Password is required")
				.Custom((password, context) =>
				{
					if (!PasswordUtils.IsValidPasswordStrength(password))
						context.AddFailure("Password should contain at least one lower case letter, upper case letter, one numeric value, one special case characters and should be greater or equal 8 characters and less or equal 30 characters");
				});
		}
	}
}

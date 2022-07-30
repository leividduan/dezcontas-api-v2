using FluentValidation;

namespace DezContas.Domain.Entities.Validators;

public class CategoryValidator : AbstractValidator<Category>
{
  public CategoryValidator()
  {
    RuleFor(c => c.Name).NotEmpty().NotNull().WithMessage("{PropertyName} is required")
      .MinimumLength(3).WithMessage("Minimum length must be 3 characters")
      .MaximumLength(150).WithMessage("Maximum length must be 100 characters");

    RuleFor(c => c.Description).MaximumLength(500).WithMessage("Maximum length must be 500 characters");

    RuleFor(c => c.Type).NotNull().NotEmpty().WithMessage("{PropertyName} is required").IsInEnum().WithMessage("{PropertyName} has a range of values which does not include '{PropertyValue}'");

    RuleFor(c => c.Id_User).NotNull().NotEmpty().WithMessage("{PropertyName} is required");
  }
}

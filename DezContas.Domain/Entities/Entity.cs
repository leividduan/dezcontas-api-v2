
using FluentValidation.Results;
using System.ComponentModel.DataAnnotations.Schema;

namespace DezContas.Domain.Entities;

public abstract class Entity
{
  public Guid Id { get; private set; }
  public DateTime CreatedAt { get; private set; }
  public DateTime UpdatedAt { get; private set; }

  [NotMapped]
  public ValidationResult ValidationResult { get; set; }

  protected Entity()
  {
    Id = Guid.NewGuid();
    var now = DateTime.Now;
    CreatedAt = now;
    UpdatedAt = now;

    ValidationResult = new ValidationResult();
  }

  public void Duplicate()
  {
    Id = Guid.Empty;
    var now = DateTime.Now;
    CreatedAt = now;
    UpdatedAt = now;
  }

  public abstract bool IsValid();

  public Error GetErrors()
  {
    var errorsDetail = ValidationResult.Errors.GroupBy(x => new { x.PropertyName }).Select(x => new ErrorDetails(x.Key.PropertyName, x.Select(s => s.ErrorMessage).ToList())).ToList();

    if (errorsDetail.Count == 0)
      return new Error(new List<ErrorDetails>());

    var errors = new Error(errorsDetail);

    return errors;
  }
}
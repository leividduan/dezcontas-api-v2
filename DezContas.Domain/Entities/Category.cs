using DezContas.Domain.Entities.Validators;

namespace DezContas.Domain.Entities;

public class Category : Entity
{
  public string Name { get; private set; }
  public string Description { get; private set; }
  public bool IsActive { get; set; }
  public Transaction.Types Type { get; private set; }
  public Guid UserId { get; private set; }

  // Relationships
  public User User { get; set; }

  public Category(string name, string description, bool isActive, Transaction.Types type, Guid userId)
  {
    Name = name;
    Description = description;
    IsActive = isActive;
    Type = type;
    UserId = userId;
  }

  public Category()
  {
  }

  public void AssociateIdUser(Guid userId)
  {
    UserId = userId;
  }

  public void Edit(string name, string description, bool isActive, Transaction.Types type)
  {
    Name = name;
    Description = description;
    IsActive = isActive;
    Type = type;
  }

  public override bool IsValid()
  {
    ValidationResult = new CategoryValidator().Validate(this);
    return ValidationResult.IsValid;
  }
}

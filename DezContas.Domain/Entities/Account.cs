using DezContas.Domain.Entities.Validators;

namespace DezContas.Domain.Entities;

public class Account : Entity
{
  public enum Types
  {
    General = 1,
    Saving = 2,
  }

  public string Name { get; private set; }
  public string Description { get; private set; }
  public bool IsDefault { get; private set; }
  public bool IsActive { get; private set; }
  public Types Type { get; private set; }
  public Guid UserId { get; private set; }


  // Relationships
  public User User { get; set; }

  public Account()
  {
  }

  public Account(string name, string description, bool isDefault, bool isActive, Types type, Guid userId)
  {
    Name = name;
    Description = description;
    IsDefault = isDefault;
    IsActive = isActive;
    Type = type;
    UserId = userId;
  }

  public void AssociateIdUser(Guid userId)
  {
    UserId = userId;
  }

  public void Edit(string name, string description, bool isDefault, bool isActive, Types type)
  {
    Name = name;
    Description = description;
    IsDefault = isDefault;
    IsActive = isActive;
    Type = type;
  }

  public void Activate()
  {
    IsActive = true;
  }

  public void Deactivate()
  {
    IsActive = false;
  }

  public void SetIsDefault(bool value)
  {
    IsDefault = value;
  }

  public override bool IsValid()
  {
    ValidationResult = new AccountValidator().Validate(this);
    return ValidationResult.IsValid;
  }
}

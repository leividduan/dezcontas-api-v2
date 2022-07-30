using DezContas.Domain.Entities.Validators;
using DezContas.Domain.Utils;

namespace DezContas.Domain.Entities;

public class User : Entity
{
  public string Name { get; private set; }
  public string Username { get; private set; }
  public string Email { get; private set; }
  public string Password { get; private set; }
  public bool IsActive { get; private set; }

  // Relationships
  public ICollection<Account> Account { get; private set; }
  public ICollection<Category> Category { get; private set; }

  public User()
  {
  }

  public User(string name, string username, string email, string password, bool isActive)
  {
    Name = name;
    Username = username;
    Email = email;
    Password = password;
    IsActive = isActive;
  }

  public void Activate()
  {
    IsActive = true;
  }

  public void Deactivate()
  {
    IsActive = false;
  }

  public void HashPassword()
  {
    Password = PasswordUtils.HashPassword(Password);
  }

  public override bool IsValid()
  {
    ValidationResult = new UserValidator().Validate(this);
    return ValidationResult.IsValid;
  }
}

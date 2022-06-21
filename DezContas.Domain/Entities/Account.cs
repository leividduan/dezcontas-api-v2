using DezContas.Domain.Entities.Validators;

namespace DezContas.Domain.Entities
{
	public enum Type
	{
		General = 1,
		Saving = 2,
	}

	public class Account : Entity
	{
		public string Name { get; private set; }
		public string Description { get; private set; }
		public bool IsDefault { get; private set; }
		public bool IsActive { get; private set; }
		public Type Type { get; private set; }
		public Guid Id_User { get; private set; }


		// Relationships
		public User User { get; set; }

		public Account()
		{
		}

		public Account(string name, string description, bool isDefault, bool isActive, Type type, Guid idUser)
		{
			Name = name;
			Description = description;
			IsDefault = isDefault;
			IsActive = isActive;
			Type = type;
			Id_User = idUser;
		}

		public void AssociateUser(Guid idUser)
		{
			Id_User = idUser;
		}

		public override bool IsValid()
		{
			ValidationResult = new AccountValidator().Validate(this);
			return ValidationResult.IsValid;
		}
	}
}

using DezContas.Domain.Entities.Validators;
using DezContas.Domain.Enums;

namespace DezContas.Domain.Entities
{
	public class Category : Entity
	{
		public string Name { get; private set; }
		public string Description { get; private set; }
		public bool IsActive { get; set; }
		public ECategoryType Type { get; private set; }
		public Guid Id_User { get; private set; }

		// Relationships
		public User User { get; set; }

		public Category(string name, string description, bool isActive, ECategoryType type, Guid id_User)
		{
			Name = name;
			Description = description;
			IsActive = isActive;
			Type = type;
			Id_User = id_User;
		}

		public Category()
		{
		}

		public void AssociateIdUser(Guid idUser)
		{
			Id_User = idUser;
		}

		public override bool IsValid()
		{
			ValidationResult = new CategoryValidator().Validate(this);
			return ValidationResult.IsValid;
		}
	}
}

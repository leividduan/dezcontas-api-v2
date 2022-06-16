using DezContas.Domain.Entities.Validators;

namespace DezContas.Domain.Entities
{
	public class User : Entity
	{
		public string Name { get; set; }
		public string AtSign { get; set; }
		public string Email { get; set; }
		public string Password { get; set; }

		public User()
		{
		}

		public User(string name, string atSign, string email, string password)
		{
			Name = name;
			AtSign = atSign;
			Email = email;
			Password = password;
		}

		public override bool IsValid()
		{
			ValidationResult = new UserValidator().Validate(this);
			return ValidationResult.IsValid;
		}
	}
}

using DezContas.Domain.Entities.Validators;
using System.Security.Cryptography;
using System.Text;

namespace DezContas.Domain.Entities
{
	public class User : Entity
	{
		public string Name { get; set; }
		public string Username { get; set; }
		public string Email { get; set; }
		public string Password { get; set; }
		public bool IsActive { get; set; }

		// Relationships
		public ICollection<Account> Account { get; set; }

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

		public string HashPassword(string password)
		{
			if (string.IsNullOrEmpty(password))
				return string.Empty;

			var input = Encoding.UTF8.GetBytes(password);
			using (var hashAlgorithm = HashAlgorithm.Create("sha256"))
			{
				return Convert.ToBase64String(hashAlgorithm.ComputeHash(input));
			}
		}

		public bool VerifyPassword(string passwordToVerify, string passwordVerified)
		{
			var hash = HashPassword(passwordToVerify);
			return hash == passwordVerified;
		}

		public override bool IsValid()
		{
			ValidationResult = new UserValidator().Validate(this);
			return ValidationResult.IsValid;
		}
	}
}

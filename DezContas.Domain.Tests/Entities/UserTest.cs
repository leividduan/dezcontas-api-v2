using DezContas.Domain.Entities;
using Xunit;

namespace DezContas.Domain.Tests.Entities
{
	public class UserTest
	{
		[Fact]
		[Trait("User", "Create")]
		public void User_Create_Successfully()
		{
			// Arrange
			var user = new User("Deivid", "leividduan", "deivid.cardos@gmail.com", "@Teste123", true);

			// Act - Assert
			Assert.True(user.IsValid());
		}

		[Fact]
		[Trait("User", "Create")]
		public void User_Create_WithoutName()
		{
			// Arrange
			var user = new User(string.Empty, "leividduan", "deivid.cardos@gmail.com", "@Teste123", true);

			// Act - Assert
			Assert.False(user.IsValid());
		}


		[Fact]
		[Trait("User", "Create")]
		public void User_Create_WithoutUsername()
		{
			// Arrange
			var user = new User("Deivid", string.Empty, "deivid.cardos@gmail.com", "@Teste123", true);

			// Act - Assert
			Assert.False(user.IsValid());
		}

		[Fact]
		[Trait("User", "Create")]
		public void User_Create_WithoutEmail()
		{
			// Arrange
			var user = new User("Deivid", "leividduan", string.Empty, "@Teste123", true);

			// Act - Assert
			Assert.False(user.IsValid());
		}

		[Fact]
		[Trait("User", "Create")]
		public void User_Create_WithInvalidEmail()
		{
			// Arrange
			var user = new User("Deivid", "leividduan", "teste.com", "@Teste123", true);

			// Act - Assert
			Assert.False(user.IsValid());
			Assert.NotEmpty(user.GetErrors().Errors);
		}

		[Fact]
		[Trait("User", "Create")]
		public void User_Create_WithoutPassword()
		{
			// Arrange
			var user = new User("Deivid", "leividduan", "deivid.cardos@gmail.com", string.Empty, true);

			// Act - Assert
			Assert.False(user.IsValid());
		}

		[Fact]
		[Trait("User", "Create")]
		public void User_Create_WithInvalidPassword()
		{
			// Arrange
			var user = new User("Deivid", "leividduan", "deivid.cardos@gmail.com", "teste123", true);

			// Act - Assert
			Assert.False(user.IsValid());
		}

		[Fact]
		[Trait("User", "IsActive")]
		public void User_IsActive_Activate()
		{
			// Arrange
			var isActive = false;
			var user = new User("Deivid", "leividduan", "deivid.cardos@gmail.com", "@Teste123", isActive);

			// Act
			user.Activate();

			// Assert
			Assert.True(user.IsActive);
			Assert.True(isActive != user.IsActive);
		}

		[Fact]
		[Trait("User", "IsActive")]
		public void User_IsActive_Deactivate()
		{
			// Arrange
			var isActive = true;
			var user = new User("Deivid", "leividduan", "deivid.cardos@gmail.com", "@Teste123", isActive);

			// Act
			user.Deactivate();

			// Assert
			Assert.False(user.IsActive);
			Assert.True(isActive != user.IsActive);
		}

		[Fact]
		[Trait("User", "HashPassword")]
		public void User_HashPassword_Ok()
		{
			// Arrange
			var encryptedPassword = "vo+5dOWzaRpj4R1lzlRYQyOfGePIUJ5Jdt57no3QnW0=";
			var user = new User("Deivid", "leividduan", "deivid.cardos@gmail.com", "@Teste123", true);

			// Act
			user.HashPassword();

			// Assert
			Assert.True(encryptedPassword.Equals(user.Password));
		}

		[Fact]
		[Trait("User", "HashPassword")]
		public void User_HashPassword_NotOk()
		{
			// Arrange
			var encryptedPassword = "@Teste123";
			var user = new User("Deivid", "leividduan", "deivid.cardos@gmail.com", "@Teste123", true);

			// Act
			user.HashPassword();

			// Assert
			Assert.False(encryptedPassword.Equals(user.Password));
		}
	}
}

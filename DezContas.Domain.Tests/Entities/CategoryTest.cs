using DezContas.Domain.Entities;
using System;
using Xunit;

namespace DezContas.Domain.Tests.Entities
{
	public class CategoryTest
	{
		[Fact]
		[Trait("Category", "Create")]
		public void Category_Create_Successfully()
		{
			// Arrange
			var category = new Category("Nome teste", "Descrição teste", true, Transaction.Types.Income, System.Guid.NewGuid());

			// Act - Assert
			Assert.True(category.IsValid());
		}

		[Fact]
		[Trait("Category", "Create")]
		public void Category_Create_Without_Name()
		{
			// Arrange
			var category = new Category(string.Empty, "Descrição teste", true, Transaction.Types.Income, System.Guid.NewGuid());

			// Act - Assert
			Assert.False(category.IsValid());
		}

		[Fact]
		[Trait("Category", "Create")]
		public void Category_Create_Without_Description()
		{
			// Arrange
			var category = new Category("Nome teste", string.Empty, true, Transaction.Types.Income, System.Guid.NewGuid());

			// Act - Assert
			Assert.True(category.IsValid());
		}

		[Fact]
		[Trait("Category", "Create")]
		public void Category_Create_With_Wrong_Type()
		{
			// Arrange
			var category = new Category("Nome teste", string.Empty, true, (Transaction.Types)10, System.Guid.NewGuid());

			// Act - Assert
			Assert.False(category.IsValid());
		}

		[Fact]
		[Trait("Category", "Create")]
		public void Category_Create_Name_With_MinLenght()
		{
			// Arrange
			var category = new Category("No", string.Empty, true, Transaction.Types.Income, System.Guid.NewGuid());

			// Act - Assert
			Assert.False(category.IsValid());
		}

		[Fact]
		[Trait("Category", "Create")]
		public void Category_Create_Name_With_MaxLenght()
		{
			// Arrange
			var category = new Category("Lorem ipsum dolor sit amet, consectetur adipiscing elit. Pellentesque nulla mi, fringilla at fermentum vitae, tincidunt eu eros. Etiam cursus eros eu..", string.Empty, true, Transaction.Types.Expense, System.Guid.NewGuid());

			// Act - Assert
			Assert.False(category.IsValid());
		}

		[Fact]
		[Trait("Category", "Create")]
		public void Category_Create_Description_With_MaxLenght()
		{
			// Arrange
			var description = @"Lorem ipsum dolor sit amet, consectetur adipiscing elit. Cras convallis arcu leo, eu rutrum orci imperdiet in. In hac habitasse platea dictumst. Vivamus neque purus, tincidunt quis ultrices nec, maximus id nunc. Mauris ullamcorper sem sit amet neque bibendum, vitae convallis libero faucibus. Aenean ornare euismod sollicitudin. Donec vitae orci nisl. Sed pharetra, libero a imperdiet imperdiet, nibh sem molestie tortor, a egestas nunc nulla id dui. Donec consequat dolor eu lacinia cursus. In proin.";
			var category = new Category("Nome teste", description, true, Transaction.Types.Expense, System.Guid.NewGuid());

			// Act - Assert
			Assert.False(category.IsValid());
		}

		[Fact]
		[Trait("Category", "Create")]
		public void Category_Create_Without_IdUser()
		{
			// Arrange
			var category = new Category("Nome teste", string.Empty, true, Transaction.Types.Income, System.Guid.Empty);

			// Act - Assert
			Assert.False(category.IsValid());
		}

		[Fact]
		[Trait("Category", "AssociateUser")]
		public void Category_AssociateUser_Ok()
		{
			// Arrange
			var oldIdUser = Guid.NewGuid();
			var idUser = Guid.NewGuid();
			var category = new Category("Nome teste", string.Empty, true, Transaction.Types.Income, oldIdUser);

			// Act
			category.AssociateIdUser(idUser);

			// Assert
			Assert.True(category.Id_User.Equals(idUser));
			Assert.False(category.Id_User.Equals(oldIdUser));
		}
	}
}

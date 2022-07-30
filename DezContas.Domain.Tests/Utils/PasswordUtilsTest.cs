using DezContas.Domain.Utils;
using Xunit;

namespace DezContas.Domain.Tests.Utils;

public class PasswordUtilsTest
{
  [Fact]
  [Trait("PasswordUtils", "IsValidPasswordStrength")]
  public void PasswordUtils_IsValidPasswordStrength_Ok()
  {
    // Arrange
    var password = "@Teste123";

    // Act
    var result = PasswordUtils.IsValidPasswordStrength(password);

    // Assert
    Assert.True(result);
  }

  [Fact]
  [Trait("PasswordUtils", "IsValidPasswordStrength")]
  public void PasswordUtils_IsValidPasswordStrength_NotOk()
  {
    // Arrange
    var password = "teste123";

    // Act
    var result = PasswordUtils.IsValidPasswordStrength(password);

    // Assert
    Assert.False(result);
  }

  [Fact]
  [Trait("PasswordUtils", "HashPassword")]
  public void PasswordUtils_HashPassword_Ok()
  {
    // Arrange
    var password = "@Teste123";
    var encryptedPassword = "vo+5dOWzaRpj4R1lzlRYQyOfGePIUJ5Jdt57no3QnW0=";

    // Act
    var result = PasswordUtils.HashPassword(password);

    // Assert
    Assert.True(encryptedPassword.Equals(result));
  }

  [Fact]
  [Trait("PasswordUtils", "HashPassword")]
  public void PasswordUtils_HashPassword_NotOk()
  {
    // Arrange
    var password = "@Teste123";
    var encryptedPassword = "@Teste123";

    // Act
    var result = PasswordUtils.HashPassword(password);

    // Assert
    Assert.False(encryptedPassword.Equals(result));
  }

  [Fact]
  [Trait("PasswordUtils", "VerifyPassword")]
  public void PasswordUtils_VerifyPassword_Ok()
  {
    // Arrange
    var passwordToVerify = "@Teste123";
    var passwordVerified = "vo+5dOWzaRpj4R1lzlRYQyOfGePIUJ5Jdt57no3QnW0=";

    // Act
    var result = PasswordUtils.VerifyPassword(passwordToVerify, passwordVerified);

    // Assert
    Assert.True(result);
  }

  [Fact]
  [Trait("PasswordUtils", "VerifyPassword")]
  public void PasswordUtils_VerifyPassword_NotOk()
  {
    // Arrange
    var passwordToVerify = "@Teste123";
    var passwordVerified = "@Teste1234";

    // Act
    var result = PasswordUtils.VerifyPassword(passwordToVerify, passwordVerified);

    // Assert
    Assert.False(result);
  }
}

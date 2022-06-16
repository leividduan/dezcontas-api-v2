using System.Text.RegularExpressions;

namespace DezContas.Domain.Utils
{
	public static class PasswordUtils
	{
		public static bool IsValidPasswordStrength(string password)
		{
			if (string.IsNullOrEmpty(password)) return false;

			var hasNumber = new Regex(@"[0-9]+");
			var hasUpperChar = new Regex(@"[A-Z]+");
			var hasMiniMaxChars = new Regex(@".{8,30}");
			var hasLowerChar = new Regex(@"[a-z]+");
			var hasSymbols = new Regex(@"[!@#$%^&*()_+=\[{\]};:<>|./?,-]");

			return hasNumber.IsMatch(password) && hasUpperChar.IsMatch(password) && hasMiniMaxChars.IsMatch(password) && hasLowerChar.IsMatch(password) && hasSymbols.IsMatch(password);
		}
	}
}

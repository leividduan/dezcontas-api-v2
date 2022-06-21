using System.Security.Claims;

namespace DezContas.API.Helpers
{
	public static class GetClaim
	{
		public static Guid GetUserIdClaim(this IEnumerable<Claim> claims)
		{
			return Guid.Parse(claims.First(x => x.Type == "Id_User").Value);
		}
	}
}

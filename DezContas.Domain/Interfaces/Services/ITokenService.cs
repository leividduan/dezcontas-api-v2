using DezContas.Domain.Entities;

namespace DezContas.Domain.Interfaces.Services
{
	public interface ITokenService
	{
		string GenerateToken(User user);
	}
}

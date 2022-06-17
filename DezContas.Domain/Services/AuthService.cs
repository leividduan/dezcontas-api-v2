using DezContas.Domain.Entities;
using DezContas.Domain.Interfaces.Repositories;
using DezContas.Domain.Interfaces.Services;

namespace DezContas.Domain.Services
{
	public class AuthService : IAuthService
	{

		private readonly IUserRepository _repository;
		private readonly ITokenService _tokenService;
		public AuthService(IUserRepository repository, ITokenService tokenService)
		{
			_repository = repository;
			_tokenService = tokenService;
		}

		public async Task<dynamic> Login(User user)
		{
			var savedUser = await _repository.GetSingle(x => x.Username == user.Username);
			if (savedUser != null)
			{
				if (user.VerifyPassword(user.Password, savedUser.Password))
				{
					var token = _tokenService.GenerateToken(savedUser);
					return new
					{
						id = savedUser.Id,
						name = savedUser.Name,
						username = savedUser.Username,
						email = savedUser.Email,
						token = token
					};
				}
			}

			return null;
		}
	}
}

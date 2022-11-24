using DezContas.Domain.Entities;
using DezContas.Domain.Interfaces.Repositories;
using DezContas.Domain.Interfaces.Services;
using DezContas.Domain.Utils;

namespace DezContas.Domain.Services;

public class AuthService : IAuthService
{
  private readonly IUserRepository _repository;
  private readonly ITokenService _tokenService;
  public AuthService(IUserRepository repository, ITokenService tokenService)
  {
    _repository = repository;
    _tokenService = tokenService;
  }

  public async Task<(bool IsLogged, dynamic Data)> Login(User user)
  {
    var savedUser = await _repository.GetSingle(x => x.Username == user.Username);
    if (savedUser != null && PasswordUtils.VerifyPassword(user.Password, savedUser.Password))
    {
      var token = _tokenService.GenerateToken(savedUser);
      return (true, new
      {
        id = savedUser.Id,
        name = savedUser.Name,
        username = savedUser.Username,
        email = savedUser.Email,
        token
      });
    }

    return (false, null);
  }
}

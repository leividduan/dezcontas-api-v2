using DezContas.Domain.Entities;

namespace DezContas.Domain.Interfaces.Services;

public interface IAuthService
{
  public Task<(bool IsLogged, dynamic Data)> Login(User user);
}

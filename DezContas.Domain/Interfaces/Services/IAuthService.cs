using DezContas.Domain.Entities;

namespace DezContas.Domain.Interfaces.Services;

public interface IAuthService
{
  public Task<dynamic> Login(User user);
}

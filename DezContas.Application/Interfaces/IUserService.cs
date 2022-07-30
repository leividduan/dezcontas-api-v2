using DezContas.Domain.Entities;
using PlayPedidos.Application.Interfaces;

namespace DezContas.Application.Interfaces;

public interface IUserService : IServiceBase<User>
{
  Task<bool> ValidateIfExistUsernameAndEmail(User user);
}

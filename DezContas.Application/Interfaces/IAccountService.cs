using DezContas.Domain.Entities;
using PlayPedidos.Application.Interfaces;

namespace DezContas.Application.Interfaces;

public interface IAccountService : IServiceBase<Account>
{
  Task<bool> Add(Account entity, bool verifyIsDefault);
  Task<bool> Edit(Account entity, bool verifyIsDefault);
}

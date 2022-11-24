using DezContas.Application.Interfaces;
using DezContas.Domain.Entities;
using DezContas.Domain.Interfaces.Repositories;
using PlayPedidos.Application.Services;

namespace DezContas.Application.Services;

public class AccountService : ServiceBase<Account>, IAccountService
{
  private readonly IAccountRepository _repository;
  public AccountService(IAccountRepository repository) : base(repository)
  {
    _repository = repository;
  }

  public async Task<bool> Add(Account entity, bool verifyIsDefault)
  {
    if (verifyIsDefault)
      await SetOthersAccountsIsNotDefault(entity.Id, entity.UserId);

    await _repository.Edit(entity);
    return entity != null;
  }

  public async Task<bool> Edit(Account entity, bool verifyIsDefault)
  {
    if (verifyIsDefault)
      await SetOthersAccountsIsNotDefault(entity.Id, entity.UserId);

    await _repository.Edit(entity);
    return entity != null;
  }

  private async Task SetOthersAccountsIsNotDefault(Guid idCurrentDefaultAccount, Guid idUser)
  {
    var defaultsAccounts = await _repository.Get(x => x.UserId == idUser && x.IsDefault && x.Id != idCurrentDefaultAccount);
    foreach (var defaultAccount in defaultsAccounts)
    {
      defaultAccount.SetIsDefault(false);
      await _repository.Edit(defaultAccount, false);
    }
  }
}

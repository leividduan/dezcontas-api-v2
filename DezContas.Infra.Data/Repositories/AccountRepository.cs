using DezContas.Domain.Entities;
using DezContas.Domain.Interfaces.Repositories;

namespace DezContas.Infra.Data.Repositories;

public class AccountRepository : RepositoryBase<Account>, IAccountRepository
{
  private readonly AppDbContext _context;
  public AccountRepository(AppDbContext context) : base(context)
  {
    _context = context;
  }
}

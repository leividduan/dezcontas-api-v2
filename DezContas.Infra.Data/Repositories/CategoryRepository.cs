using DezContas.Domain.Entities;
using DezContas.Domain.Interfaces.Repositories;

namespace DezContas.Infra.Data.Repositories;

public class CategoryRepository : RepositoryBase<Category>, ICategoryRepository
{
  private readonly AppDbContext _context;
  public CategoryRepository(AppDbContext context) : base(context)
  {
    _context = context;
  }
}

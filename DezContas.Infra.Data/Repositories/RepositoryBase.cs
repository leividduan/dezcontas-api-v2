using DezContas.Domain.Interfaces.Repositories;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace DezContas.Infra.Data.Repositories;

public class RepositoryBase<TEntity> : IDisposable, IRepositoryBase<TEntity> where TEntity : class
{
  private readonly AppDbContext _context;

  public RepositoryBase(AppDbContext context)
  {
    _context = context;
  }

  public async Task<bool> Add(TEntity entity)
  {
    var entityAdded = await _context.Set<TEntity>().AddAsync(entity);
    await _context.SaveChangesAsync();
    return entityAdded != null;
  }

  public async Task<bool> Edit(TEntity entity)
  {
    _context.Entry(entity).State = EntityState.Modified;
    var entityEdited = _context.Set<TEntity>().Update(entity);
    await _context.SaveChangesAsync();
    return entityEdited != null;
  }

  public async Task<bool> Delete(TEntity entity)
  {
    _context.Set<TEntity>().Remove(entity);
    return await _context.SaveChangesAsync() > 0;
  }

  public async Task<int> Save()
  {
    return await _context.SaveChangesAsync();
  }

  public Task<TEntity> GetSingle(Expression<Func<TEntity, bool>> filter = null, string include = null)
  {
    Task<TEntity?> entity = null;

    if (string.IsNullOrEmpty(include))
      entity = _context.Set<TEntity>().SingleOrDefaultAsync(filter);
    else
      entity = _context.Set<TEntity>().Include(include).SingleOrDefaultAsync(filter);

    return entity;
  }

  public async Task<IEnumerable<TEntity>> Get(Expression<Func<TEntity, bool>> filter = null, string include = null)
  {
    var entities = _context.Set<TEntity>().AsNoTracking();

    if (!String.IsNullOrEmpty(include))
      entities = entities.Include(include);
    if (filter != null)
      entities = entities.Where(filter);

    return await entities.ToListAsync();
  }

  public void Dispose()
  {
    _context?.Dispose();
  }
}

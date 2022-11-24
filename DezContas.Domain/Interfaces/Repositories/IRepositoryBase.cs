using System.Linq.Expressions;

namespace DezContas.Domain.Interfaces.Repositories;

public interface IRepositoryBase<TEntity> : IDisposable where TEntity : class
{
  public Task<TEntity> GetSingle(Expression<Func<TEntity, bool>>? filter = null, string? include = null);
  public Task<IEnumerable<TEntity>> Get(Expression<Func<TEntity, bool>>? filter = null, string? include = null);
  public Task<bool> Add(TEntity entity, bool saveChanges = true);
  public Task<bool> Edit(TEntity entity, bool saveChanges = true);
  public Task<bool> Delete(TEntity entity, bool saveChanges = true);
  public Task<int> Save();
}

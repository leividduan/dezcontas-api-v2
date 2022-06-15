using DezContas.Domain.Interfaces.Repositories;
using PlayPedidos.Application.Interfaces;
using System.Linq.Expressions;

namespace PlayPedidos.Application.Services
{
	public class ServiceBase<TEntity> : IDisposable, IServiceBase<TEntity> where TEntity : class
	{
		private readonly IRepositoryBase<TEntity> _repository;
		public ServiceBase(IRepositoryBase<TEntity> repository)
		{
			_repository = repository;
		}

		public async Task<bool> Add(TEntity entity)
		{
			return await _repository.Add(entity);
		}

		public async Task<bool> Edit(TEntity entity)
		{
			return await _repository.Edit(entity);
		}

		public async Task<bool> Delete(TEntity entity)
		{
			return await _repository.Delete(entity);
		}

		public async Task<int> Save()
		{
			return await _repository.Save();
		}

		public async Task<TEntity> GetSingle(Expression<Func<TEntity, bool>> filter = null, string include = null)
		{
			return await _repository.GetSingle(filter, include);
		}

		public async Task<IEnumerable<TEntity>> Get(Expression<Func<TEntity, bool>> filter = null, string include = null)
		{
			return await _repository.Get(filter, include);
		}

		public void Dispose()
		{
			_repository?.Dispose();
		}
	}
}

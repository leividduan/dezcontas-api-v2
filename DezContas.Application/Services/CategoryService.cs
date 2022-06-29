using DezContas.Application.Interfaces;
using DezContas.Domain.Entities;
using DezContas.Domain.Interfaces.Repositories;
using PlayPedidos.Application.Services;

namespace DezContas.Application.Services
{
	public class CategoryService : ServiceBase<Category>, ICategoryService
	{
		private readonly ICategoryRepository _repository;
		public CategoryService(ICategoryRepository repository) : base(repository)
		{
			_repository = repository;
		}
	}
}

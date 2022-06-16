using DezContas.Application.Interfaces;
using DezContas.Domain.Entities;
using DezContas.Domain.Interfaces.Repositories;
using PlayPedidos.Application.Services;

namespace DezContas.Application.Services
{
	public class UserService : ServiceBase<User>, IUserService
	{
		private readonly IUserRepository _repository;
		public UserService(IUserRepository repository) : base(repository)
		{
			_repository = repository;
		}
	}
}

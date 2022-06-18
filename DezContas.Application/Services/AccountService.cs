using DezContas.Application.Interfaces;
using DezContas.Domain.Entities;
using DezContas.Domain.Interfaces.Repositories;
using PlayPedidos.Application.Services;

namespace DezContas.Application.Services
{
	public class AccountService : ServiceBase<Account>, IAccountService
	{
		private readonly IAccountRepository _repository;
		public AccountService(IAccountRepository repository) : base(repository)
		{
			_repository = repository;
		}
	}
}

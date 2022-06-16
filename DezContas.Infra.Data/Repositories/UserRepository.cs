using DezContas.Domain.Entities;
using DezContas.Domain.Interfaces.Repositories;

namespace DezContas.Infra.Data.Repositories
{
	public class UserRepository : RepositoryBase<User>, IUserRepository
	{
		private readonly AppDbContext _context;
		public UserRepository(AppDbContext context) : base(context)
		{
			_context = context;
		}
	}
}

using DezContas.Data.Repositories;
using DezContas.Domain.Interfaces.Repositories;
using DezContas.Infra.Data;
using FluentValidation;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using PlayPedidos.Application.Interfaces;
using PlayPedidos.Application.Services;
using System.Reflection;

namespace DezContas.Infra.IoC
{
	public static class DependencyInjection
	{
		public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
		{
			var connectionString = configuration.GetConnectionString("MySqlConnection");
			services.AddDbContext<AppDbContext>(options =>
																		options.UseMySql(connectionString, ServerVersion.AutoDetect(connectionString)));

			services.AddServices();
			services.AddRepositories();
			services.AddFluentValidations();

			return services;
		}

		public static IServiceCollection AddRepositories(this IServiceCollection services)
		{
			services.AddScoped(typeof(IRepositoryBase<>), typeof(RepositoryBase<>));

			return services;
		}

		public static IServiceCollection AddServices(this IServiceCollection services)
		{
			services.AddScoped(typeof(IServiceBase<>), typeof(ServiceBase<>));

			return services;
		}

		public static IServiceCollection AddFluentValidations(this IServiceCollection services)
		{
			return services.AddValidatorsFromAssembly(Assembly.Load("DezContas.Domain"), ServiceLifetime.Transient);
		}
	}
}

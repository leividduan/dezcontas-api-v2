using DezContas.Application.Interfaces;
using DezContas.Application.Services;
using DezContas.Domain.Interfaces.Repositories;
using DezContas.Domain.Interfaces.Services;
using DezContas.Domain.Services;
using DezContas.Infra.Data;
using DezContas.Infra.Data.Repositories;
using FluentValidation;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.IdentityModel.Tokens;
using PlayPedidos.Application.Interfaces;
using PlayPedidos.Application.Services;
using System.Reflection;
using System.Text;

namespace DezContas.Infra.IoC
{
	public static class DependencyInjection
	{
		public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
		{
			var connectionString = configuration.GetConnectionString("MySqlConnection");
			services.AddDbContext<AppDbContext>(options =>
																		options.UseMySql(connectionString, ServerVersion.AutoDetect(connectionString)));

			services.AddAppServices();
			services.AddDomainServices();
			services.AddRepositories();
			services.AddJwtAuthentication(configuration);
			services.AddFluentValidations();


			return services;
		}

		public static IServiceCollection AddRepositories(this IServiceCollection services)
		{
			services.AddScoped(typeof(IRepositoryBase<>), typeof(RepositoryBase<>));
			services.AddScoped<IUserRepository, UserRepository>();

			return services;
		}

		public static IServiceCollection AddAppServices(this IServiceCollection services)
		{
			services.AddScoped(typeof(IServiceBase<>), typeof(ServiceBase<>));
			services.AddScoped<IUserService, UserService>();

			return services;
		}

		public static IServiceCollection AddDomainServices(this IServiceCollection services)
		{
			services.AddScoped<ITokenService, TokenService>();
			services.AddScoped<IAuthService, AuthService>();

			return services;
		}

		public static IServiceCollection AddJwtAuthentication(this IServiceCollection services, IConfiguration configuration)
		{
			var key = Encoding.ASCII.GetBytes(configuration.GetValue<string>("TokenJwt"));
			services.AddAuthentication(x =>
			{
				x.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
				x.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
			})
			.AddJwtBearer(x =>
			{
				x.RequireHttpsMetadata = false;
				x.SaveToken = true;
				x.TokenValidationParameters = new TokenValidationParameters
				{
					ValidateIssuerSigningKey = true,
					IssuerSigningKey = new SymmetricSecurityKey(key),
					ValidateIssuer = false,
					ValidateAudience = false
				};
			});

			return services;
		}

		public static IServiceCollection AddFluentValidations(this IServiceCollection services)
		{
			return services.AddValidatorsFromAssembly(Assembly.Load("DezContas.Domain"), ServiceLifetime.Transient);
		}

		public static IHost MigrateDatabase(this IHost host)
		{
			using (var scope = host.Services.CreateScope())
			{
				var db = scope.ServiceProvider.GetRequiredService<AppDbContext>();
				db.Database.Migrate();
			}

			return host;
		}
	}
}

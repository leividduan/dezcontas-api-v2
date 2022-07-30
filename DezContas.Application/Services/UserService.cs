using DezContas.Application.Interfaces;
using DezContas.Domain.Entities;
using DezContas.Domain.Interfaces.Repositories;
using FluentValidation.Results;
using PlayPedidos.Application.Services;

namespace DezContas.Application.Services;

public class UserService : ServiceBase<User>, IUserService
{
  private readonly IUserRepository _repository;
  public UserService(IUserRepository repository) : base(repository)
  {
    _repository = repository;
  }

  public async Task<bool> ValidateIfExistUsernameAndEmail(User user)
  {
    var existingEmail = await _repository.GetSingle(x => x.Email == user.Email);
    if (existingEmail != null)
      user.ValidationResult.Errors.Add(new ValidationFailure(nameof(user.Email), "This Email is already being used"));

    var existingUsername = await _repository.GetSingle(x => x.Username == user.Username);
    if (existingUsername != null)
      user.ValidationResult.Errors.Add(new ValidationFailure(nameof(user.Username), "This Username is already being used"));

    return user.ValidationResult.IsValid;
  }
}

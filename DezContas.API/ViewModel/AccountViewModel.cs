namespace DezContas.API.ViewModel
{
	public record AccountViewModel(
		Guid Id,
		string Name,
		string Description,
		bool IsDefault,
		bool IsActive,
		Domain.Entities.Type Type,
		Guid Id_User,
		DateTime CreatedAt,
		DateTime UpdatedAt
	);

	public record AccountPostViewModel(
		string Name,
		string Description,
		bool IsDefault,
		bool IsActive,
		Domain.Entities.Type Type,
		Guid Id_User
	);

	public record AccountPutViewModel(
		Guid Id,
		string Name,
		string Description,
		bool IsDefault,
		bool IsActive,
		Domain.Entities.Type Type,
		Guid Id_User
	);
}

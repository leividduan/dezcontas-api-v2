namespace DezContas.API.ViewModel
{
	public record CategoryViewModel(
		Guid Id,
		string Name,
		string Description,
		Domain.Enums.ECategoryType Type,
		bool IsActive,
		Guid Id_User,
		DateTime CreatedAt,
		DateTime UpdatedAt
	);

	public record CategoryPostViewModel(
		string Name,
		string Description,
		bool IsActive,
		Domain.Enums.ECategoryType Type
	);

	public record CategoryPutViewModel(
		Guid Id,
		string Name,
		string Description,
		bool IsActive,
		Domain.Enums.ECategoryType Type
	);
}

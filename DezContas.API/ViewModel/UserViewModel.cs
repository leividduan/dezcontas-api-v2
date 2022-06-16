namespace DezContas.API.ViewModel
{
	public record UserViewModel(
		Guid Id,
		string Name,
		string AtSign,
		string Email,
		bool IsActive,
		DateTime CreatedAt,
		DateTime UpdatedAt
	);

	public record UserPostViewModel(
		string Name,
		string AtSign,
		string Email,
		string Password
	);

	public record UserPutViewModel(
		Guid Id,
		string Name,
		string AtSign,
		string Password,
		bool IsActive
	);
}

namespace PlayPedidos.API.ViewModel
{
	public record ErrorViewModel(
		List<ErrorDetailsViewModel> Errors
	);

	public record ErrorDetailsViewModel(
		string Field,
		List<string> Messages
	);
}

namespace Inventory.Api.Module.Auth.Adapter.Web.Request
{
	public record ChangePasswordRequest(
		string CurrentPassword,
		string NewPassword
	);
}
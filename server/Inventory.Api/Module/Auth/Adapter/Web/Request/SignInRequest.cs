namespace Inventory.Api.Module.Auth.Adapter.Web.Request
{
	public record SignInRequest(
		string Username,
		string Password
	);
}
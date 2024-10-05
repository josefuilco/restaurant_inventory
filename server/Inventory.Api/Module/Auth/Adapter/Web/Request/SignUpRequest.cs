using Inventory.Api.Module.Auth.Domain.Enums;

namespace Inventory.Api.Module.Auth.Adapter.Web.Request
{
	public record SignUpRequest(
		string Username,
		string Password,
		string Email,
		UserRole Role
	);
}
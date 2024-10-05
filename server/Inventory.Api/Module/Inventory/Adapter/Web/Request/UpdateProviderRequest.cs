namespace Inventory.Api.Module.Inventory.Adapter.Web.Request
{
	public record UpdateProviderRequest(
		int Id,
		string Cellphone
	);
}
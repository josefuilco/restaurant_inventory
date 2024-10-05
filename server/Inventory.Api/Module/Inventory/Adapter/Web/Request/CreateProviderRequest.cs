namespace Inventory.Api.Module.Inventory.Adapter.Web.Request
{
	public record CreateProviderRequest(
		string Name,
		string Cellphone
	);
}
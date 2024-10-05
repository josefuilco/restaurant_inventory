namespace Inventory.Api.Module.Inventory.Adapter.Web.Request
{
	public record RemoveProductRequest(
		int ProductId,
		int UserId
	);
}
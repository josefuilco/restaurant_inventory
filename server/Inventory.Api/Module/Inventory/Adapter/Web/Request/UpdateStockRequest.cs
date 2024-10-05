namespace Inventory.Api.Module.Inventory.Adapter.Web.Request
{
	public record UpdateStockRequest(
		int Id,
		int Quantity,
		int UserId
	);
}
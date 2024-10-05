namespace Inventory.Api.Module.Inventory.Adapter.Web.Request
{
	public record UpdateProductRequest(
		int Id,
		string Name,
		decimal Price,
		int Quantity,
		int MinimalQuantity,
		int ProviderId,
		int CategoryId,
		int UserId
	);
}
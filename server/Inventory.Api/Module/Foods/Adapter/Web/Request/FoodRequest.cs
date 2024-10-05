using Inventory.Api.Module.Foods.Domain.Enums;

namespace Inventory.Api.Module.Foods.Adapter.Web.Request
{
	public record FoodRequest(
		string Name,
		decimal Price,
		int Amount,
		FoodType Type
	);
}
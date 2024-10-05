namespace Inventory.Api.Module.Foods.Application.Dto
{
	public record FoodDto(
		int Id,
		string Name,
		decimal Price,
		int Amount,
		string Type
	);
}
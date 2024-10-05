using Inventory.Api.Module.Foods.Domain.Enums;
using Inventory.Api.Module.Foods.Domain.ValueObject;

namespace Inventory.Api.Module.Foods.Domain.Model
{
	public class Food
	{
		public int Id { get; }
		public FoodName Name { get; }
		public FoodPrice Price { get; }
		public FoodAmount Amount { get; }
		public bool IsActive { get; }
		public FoodType Type { get; }

		public Food(int id, FoodName name, FoodPrice price, FoodAmount amount, bool isActive, FoodType type)
		{
			Id = id;
			Name = name;
			Price = price;
			Amount = amount;
			IsActive = isActive;
			Type = type;
		}
	}
}
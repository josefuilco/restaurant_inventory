using Inventory.Api.Module.Foods.Domain.Enums;
using Inventory.Api.Module.Foods.Domain.Model;

namespace Inventory.Api.Module.Foods.Domain.Builder
{
	public class FoodBuilder
	{
		private int id = 0;
		private string name = "";
		private decimal price = 0m;
		private int amount = 0;
		private bool isActive = true;
		private short type = 1;
		
		#region Methods
		private void Reset()
		{
			id = 0;
			name = "";
			price = 0m;
			amount = 0;
			isActive = true;
			type = 1;
		}
		public FoodBuilder AddId(int id)
		{
			this.id = id;
			return this;
		}
		public FoodBuilder AddName(string name)
		{
			this.name = name;
			return this;
		}
		public FoodBuilder AddPrice(decimal price)
		{
			this.price = price;
			return this;
		}
		public FoodBuilder AddAmount(int amount)
		{
			this.amount = amount;
			return this;
		}
		public FoodBuilder AddIsActive(bool isActive)
		{
			this.isActive = isActive;
			return this;
		}
		public FoodBuilder AddType(short type)
		{
			this.type = type;
			return this;
		}
		public Food Build()
		{
			Food food = new(
				id,
				new(name),
				new(price),
				new(amount),
				isActive,
				(FoodType)type
			);
			Reset();
			return food;
		}
		#endregion
	}
}
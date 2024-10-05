namespace Inventory.Api.Module.Foods.Domain.ValueObject
{
	public class FoodPrice
	{
		public decimal Value { get; }

		public FoodPrice(decimal value)
		{
			if (!IsValid(value)) throw new Exception("Food-Price.Invalid");
			Value = value;
		}

		private static bool IsValid(decimal value)
		{
			return value > 0;
		}
	}
}
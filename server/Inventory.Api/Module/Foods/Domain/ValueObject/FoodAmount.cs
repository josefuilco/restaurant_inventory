namespace Inventory.Api.Module.Foods.Domain.ValueObject
{
	public class FoodAmount
	{
		public int Value { get; }

		public FoodAmount(int value)
		{
			if (!IsValid(value)) throw new Exception("Food-Amount.Invalid");
			Value = value;
		}

		private static bool IsValid(int value) => value > 0;
	}
}
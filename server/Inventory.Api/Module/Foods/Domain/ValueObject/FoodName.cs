namespace Inventory.Api.Module.Foods.Domain.ValueObject
{
	public class FoodName
	{
		public string Value { get; }

		public FoodName(string value)
		{
			if (!IsValid(value)) throw new Exception("Food-Name.Invalid");
			Value = value;
		}

		private static bool IsValid(string value)
		{
			var length = value.Length;
			return length > 0 && length <= 30;
		}
	}
}
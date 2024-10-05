namespace Inventory.Api.Module.Inventory.Domain.ValueObject
{
	public class ProductName
	{
		public string Value { get; }

		public ProductName(string value)
		{
			if (!IsValid(value)) throw new Exception("Provider-Name.Invalid");
			Value = value;
		}

		private static bool IsValid(string value) => value.Length > 0 && value.Length <= 30;
	}
}
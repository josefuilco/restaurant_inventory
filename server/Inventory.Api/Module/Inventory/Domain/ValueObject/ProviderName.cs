namespace Inventory.Api.Module.Inventory.Domain.ValueObject
{
	public class ProviderName
	{
		public string Value { get; }

		public ProviderName(string value)
		{
			if (!IsValid(value)) throw new Exception("Provider-Name.Invalid");
			Value = value;
		}

		private static bool IsValid(string value)
		{
			return value.Length > 0 && value.Length <= 30;
		}
	}
}
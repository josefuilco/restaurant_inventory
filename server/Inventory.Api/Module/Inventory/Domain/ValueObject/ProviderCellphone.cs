using System.Text.RegularExpressions;

namespace Inventory.Api.Module.Inventory.Domain.ValueObject
{
	public class ProviderCellphone
	{
		public string Value { get; }
		private static readonly Regex regex = new("[0-9]{9}");

		public ProviderCellphone(string value)
		{
			if (!IsValid(value)) throw new Exception("Provider-Cellphone.Invalid");
			Value = value;
		}

		private static bool IsValid(string value) => regex.IsMatch(value);
	}
}
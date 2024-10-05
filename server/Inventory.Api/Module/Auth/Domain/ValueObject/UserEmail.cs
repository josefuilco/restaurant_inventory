using System.Text.RegularExpressions;

namespace Inventory.Api.Module.Auth.Domain.ValueObject
{
	public class UserEmail
	{
		public string Value { get; }
		private static readonly Regex regex = new("^([a-zA-Z0-9._%-]+@[a-zA-Z0-9.-]+.[a-zA-Z]{2,})$");

		public UserEmail(string value)
		{
			if (!IsValid(value)) throw new Exception("User-Email.Invalid");
			Value = value;
		}

		private static bool IsValid(string value)
		{
			return regex.IsMatch(value);
		}
	}
}
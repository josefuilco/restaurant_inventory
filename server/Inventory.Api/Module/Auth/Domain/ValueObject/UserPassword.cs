using System.Text;

namespace Inventory.Api.Module.Auth.Domain.ValueObject
{
	public class UserPassword
	{
		public string Value { get; }

		public UserPassword(string value)
		{
			if (!IsValid(value)) throw new Exception("User-Password.Invalid");
			Value = value;
		}

		private static bool IsValid(string value)
		{
			return value.Length > 0 && value.Length <= 28;
		}

		public string EnsureEncryptPassword() => Convert.ToBase64String(Encoding.UTF8.GetBytes(Value));
	}
}
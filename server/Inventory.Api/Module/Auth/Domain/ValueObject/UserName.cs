namespace Inventory.Api.Module.Auth.Domain.ValueObject
{
	public class UserName
	{
		public string Value { get; }

		public UserName(string value)
		{
			if (!IsValid(value)) throw new Exception("User-Name.Invalid");
			Value = value;
		}

		private static bool IsValid(string value)
		{
			return value.Length > 0 && value.Length <= 25;
		}
		public string EnsureUsernameHaventSpaces() => Value.Replace(" ", "@").ToLower();
        public string EnsureUsernameHaveSpaces() => Value.Replace("@", " ").ToLower();
	}
}
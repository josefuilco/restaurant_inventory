using Inventory.Api.Module.Auth.Domain.Enums;
using Inventory.Api.Module.Auth.Domain.Model;

namespace Inventory.Api.Module.Auth.Domain.Builder
{
	public class UserBuilder
	{
		private int id;
        private string name = string.Empty;
        private string password = string.Empty;
        private string email = string.Empty;
        private DateTime creationDate = DateTime.Now;
        private bool isActive = true;
        private short role = 1;

		#region Methods
		private void Reset()
		{
			id = 0;
			name = string.Empty;
			password = string.Empty;
			email = string.Empty;
			creationDate = DateTime.Now;
			isActive = true;
			role = 1;
		}
		public UserBuilder AddId(int id)
		{
			this.id = id;
			return this;
		}
		public UserBuilder AddName(string name)
		{
			this.name = name;
			return this;
		}
		public UserBuilder AddPassword(string password)
		{
			this.password = password;
			return this;
		}
		public UserBuilder AddEmail(string email)
		{
			this.email = email;
			return this;
		}
		public UserBuilder AddCreationDate(DateTime dateTime)
		{
			this.creationDate = dateTime;
			return this;
		}
		public UserBuilder AddIsActive(bool isActive)
		{
			this.isActive = isActive;
			return this;
		}
		public UserBuilder AddRole(short role)
		{
			this.role = role;
			return this;
		}
		public User Build()
		{
			User user = new(
				id,
				new(name),
				new(password),
				new(email),
				creationDate,
				isActive,
				(UserRole)role
			);
			Reset();
			return user;
		}
		#endregion
	}
}
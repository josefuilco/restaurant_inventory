using System.Data;
using Inventory.Api.Database;
using Inventory.Api.Module.Auth.Domain.Builder;
using Inventory.Api.Module.Auth.Domain.Model;
using Inventory.Api.Module.Auth.Domain.Port.Repository;
using Microsoft.Data.SqlClient;

namespace Inventory.Api.Module.Auth.Adapter.Repository
{
	public class SqlServerUserRepository : IUserRepository
	{
		private readonly SqlServerDatabase database;

		public SqlServerUserRepository(SqlServerDatabase database)
		{
			this.database = database;
		}
		
		public async Task<bool> AddAsync(User user)
		{
			var query = "INSERT INTO USERS.USERS (vNom_User, vPass_User, vCorreo_User, dFecha_User, bActivo, tId_Rol) VALUES (@Name, @Password, @Email, @Date, @Active, @Role)";
			var isAdded = false;
			try
			{
				SqlParameter[] parameters = [
					new("@Name", SqlDbType.VarChar, 25) { Value = user.Name.EnsureUsernameHaventSpaces() },
					new("@Password", SqlDbType.VarChar, 40) { Value = user.Password.EnsureEncryptPassword() },
					new("@Email", SqlDbType.VarChar, 50) { Value = user.Email.Value },
					new("@Date", SqlDbType.DateTime) { Value = user.CreationDate },
					new("@Active", SqlDbType.Bit) { Value = user.IsActive },
					new("@Role", SqlDbType.TinyInt) { Value = user.Role }
				];
				var rowAffected = await database.ExecuteNonQueryAsync(query, parameters);
				if (rowAffected > 0) isAdded = true;
				return isAdded;
			}
			catch (SqlException ex)
			{
				Console.WriteLine("SQL Error: " + ex.Message);
				return isAdded;
			}
		}
		public async Task<int> FindIdByAuthAsync(string username, string password)
		{
			var userId = 0;
			var query = "EXEC sp_AutenticacionUsuario @Name, @Password";
			try
			{
				SqlParameter[] parameters = [
					new("@Name", SqlDbType.VarChar, 25) { Value = username },
					new("@Password", SqlDbType.VarChar, 40) { Value = password }
				];
				var table = await database.ExecuteTableQueryAsync(query, parameters);
				var firstRow = table.Rows[0];
				userId = Convert.ToByte(firstRow[0]);
				return userId;
			}
			catch (SqlException ex)
			{
				Console.WriteLine("SQL Error: " + ex.Message);
				return userId;
			}
		}
		public async Task<User> FindByIdAsync(int id)
		{
			var builder = new UserBuilder();
			var query = "SELECT * FROM USERS.USERS WHERE tId_User = @Id";
			try
			{
				SqlParameter[] parameters = [new("@Id", SqlDbType.TinyInt) { Value = id }];
				var table = await database.ExecuteTableQueryAsync(query, parameters);
				var firstRow = table.Rows[0];
				return builder.AddId(Convert.ToInt32(firstRow[0]))
					.AddName(Convert.ToString(firstRow[1])!)
					.AddPassword(Convert.ToString(firstRow[2])!)
					.AddEmail(Convert.ToString(firstRow[3])!)
					.AddCreationDate(Convert.ToDateTime(firstRow[4]))
					.AddIsActive(Convert.ToBoolean(firstRow[5]))
					.AddRole(Convert.ToByte(firstRow[6]))
					.Build();
			}
			catch (SqlException ex)
			{
				Console.WriteLine("SQL Error: " + ex.Message);
				return builder.Build();
			}
		}
		public async Task<IEnumerable<User>> GetAllAsync()
		{
			var builder = new UserBuilder();
			List<User> users = [];
			var query = "SELECT tId_User, vNom_User, vCorreo_User, dFecha_User, bActivo, tId_Rol FROM USERS.USERS";
			try
			{
				var table = await database.ExecuteTableQueryAsync(query, []);
				foreach (DataRow row in table.Rows)
				{
					users.Add(
						builder.AddId(Convert.ToInt32(row[0]))
						.AddName(Convert.ToString(row[1])!)
						.AddPassword("base-password")
						.AddEmail(Convert.ToString(row[2])!)
						.AddCreationDate(Convert.ToDateTime(row[3]))
						.AddIsActive(Convert.ToBoolean(row[4]))
						.AddRole(Convert.ToByte(row[5]))
						.Build()
					);
				}
				return users;
			}
			catch (SqlException ex)
			{
				Console.WriteLine("SQL Error: " + ex.Message);
				return users;
			}
		}
		public async Task<bool> ChangePasswordAsync(int id, string currentPassword, string newPassword)
		{
			var isChanged = false;
			var query = "EXEC sp_CambiarPassword @Id, @NewPassword, @CurrentPassword";
			try
			{
				SqlParameter[] parameters = [
					new("@Id", SqlDbType.TinyInt) { Value = id },
					new("@NewPassword", SqlDbType.VarChar, 40) { Value = newPassword },
					new("@CurrentPassword", SqlDbType.VarChar, 40) { Value = currentPassword }
				];
				var rowAffected = await database.ExecuteNonQueryAsync(query, parameters);
				if (rowAffected > 0) isChanged = true;
				Console.WriteLine("RowAffected: " + rowAffected);
				return isChanged;
			}
			catch (SqlException ex)
			{
				Console.WriteLine("SQL Error: " + ex.Message);
				return isChanged;
			}
		}
		public async Task<bool> RemoveAsync(int id)
		{
			var isRemoved = false;
			var query = "UPDATE USERS.USERS SET bActivo=0 WHERE tId_User = @Id";
			try
			{
				SqlParameter[] parameters = [
					new("@Id", SqlDbType.TinyInt) { Value = id }
				];
				var rowAffected = await database.ExecuteNonQueryAsync(query, parameters);
				if (rowAffected > 0) isRemoved = true;
				Console.WriteLine("RowAffected: " + rowAffected);
				return isRemoved;
			}
			catch (SqlException ex)
			{
				Console.WriteLine("SQL Error: " + ex.Message);
				return isRemoved;
			}
		}
	}
}
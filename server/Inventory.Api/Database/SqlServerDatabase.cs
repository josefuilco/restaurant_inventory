using System.Data;
using Microsoft.Data.SqlClient;

namespace Inventory.Api.Database
{
	public class SqlServerDatabase
	{
		private readonly string connString;

		public SqlServerDatabase(IConfiguration config)
		{
			connString = config.GetConnectionString("SqlServer")!;
		}

		#region Methods
		public async Task<DataTable> ExecuteTableQueryAsync(string query, SqlParameter[] parameters)
		{
			await using var conn = new SqlConnection(connString);
			await conn.OpenAsync();
			await using var cmd = new SqlCommand(query, conn);
			cmd.Parameters.AddRange(parameters);
			await using var reader = await cmd.ExecuteReaderAsync();
			DataTable table = new();
			table.Load(reader);
			return table;
		}
		public async Task<int> ExecuteNonQueryAsync(string query, SqlParameter[] parameters)
		{
			await using var conn = new SqlConnection(connString);
			await conn.OpenAsync();
			await using var cmd = new SqlCommand(query, conn);
			cmd.Parameters.AddRange(parameters);
			return await cmd.ExecuteNonQueryAsync();
		}
		#endregion
	}
}
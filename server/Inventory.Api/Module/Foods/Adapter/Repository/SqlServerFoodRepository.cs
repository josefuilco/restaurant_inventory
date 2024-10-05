using System.Data;
using Inventory.Api.Database;
using Inventory.Api.Module.Foods.Domain.Builder;
using Inventory.Api.Module.Foods.Domain.Enums;
using Inventory.Api.Module.Foods.Domain.Model;
using Inventory.Api.Module.Foods.Domain.Port.Repository;
using Microsoft.Data.SqlClient;

namespace Inventory.Api.Module.Foods.Adapter.Repository
{
	public class SqlServerFoodRepository : IFoodRepository
	{
		private readonly SqlServerDatabase database;

		public SqlServerFoodRepository(SqlServerDatabase database)
		{
			this.database = database;
		}
		public async Task<bool> AddAsync(Food food)
		{
			var isCreated = false;
			var query = "INSERT INTO INVENTARIO.COMIDA (vNom_Comida, dPrecio_Comida, vCant_Comida, bActivo, tId_CatComida) VALUES (@NombreComida, @PrecioComida, @CantidadComida, 1, @CategoriaComidaId)";
			try
			{
				SqlParameter[] parameters = [
					new("@NombreComida", SqlDbType.VarChar, 30) { Value = food.Name.Value },
					new("@PrecioComida", SqlDbType.Decimal) { Value = food.Price.Value },
					new("@CantidadComida", SqlDbType.Int) { Value = food.Amount.Value },
					new("@CategoriaComidaId", SqlDbType.TinyInt) { Value = food.Type }
				];
				var rowAffected = await database.ExecuteNonQueryAsync(query, parameters);
				if (rowAffected> 0) isCreated = true;
				return isCreated;
			}
			catch (SqlException ex)
			{
				Console.WriteLine("SQL Error: " + ex.Message);
				return isCreated;
			}
		}
		public async Task<IEnumerable<Food>> GetAllAsync()
		{
			var builder = new FoodBuilder();
			var query = "SELECT * FROM INVENTARIO.COMIDA WHERE bActivo = 1";
			try
			{
				var table = await database.ExecuteTableQueryAsync(query, []);
				return from DataRow row
				in table.Rows
				select builder.AddId(Convert.ToInt32(row[0]))
					.AddName(Convert.ToString(row[1])!)
					.AddPrice(Convert.ToDecimal(row[2]))
					.AddAmount(Convert.ToInt32(row[3]))
					.AddIsActive(Convert.ToBoolean(row[4]))
					.AddType(Convert.ToByte(row[5]))
					.Build();
			}
			catch (SqlException ex)
			{
				Console.WriteLine("SQL Error: " + ex.Message);
				return [];
			}
		}
		public async Task<bool> UpdateAsync(Food food)
		{
			var isUpdated = false;
			var query = "UPDATE INVENTARIO.COMIDA SET vNom_Comida = @NuevoNombre, dPrecio_Comida = @NuevoPrecio, vCant_Comida = @NuevaCantidad, tId_CatComida = @NuevaCategoriaId WHERE iId_Comida = @IdComida";
			try
			{
				SqlParameter[] parameters = [
					new("@NuevoNombre", SqlDbType.VarChar, 30) { Value = food.Name.Value },
					new("@NuevoPrecio", SqlDbType.Decimal) { Value = food.Price.Value },
					new("@NuevaCantidad", SqlDbType.Int) { Value = food.Amount.Value },
					new("@NuevaCategoriaId", SqlDbType.TinyInt) { Value = (int)food.Type },
					new("@IdComida", SqlDbType.Int) { Value = food.Id }
				];
				var rowAffected = await database.ExecuteNonQueryAsync(query, parameters);
				if (rowAffected > 0) isUpdated = true;
				return isUpdated;
			}
			catch (SqlException ex)
			{
				Console.WriteLine("SQL Error: " + ex.Message);
				return isUpdated;
			}
		}
		public async Task<bool> RemoveAsync(int Id)
		{
			var isDeleted = false;
			var query = "UPDATE INVENTARIO.COMIDA SET bActivo = 0 WHERE iId_Comida = @IdComida";
			try
			{
				var rowAffected = await database.ExecuteNonQueryAsync(query, [new("@IdComida", SqlDbType.Int){ Value = Id }]);
				if (rowAffected > 0) isDeleted = true;
				return isDeleted;
			}
			catch (SqlException ex)
			{
				Console.WriteLine("SQL Error: " + ex.Message);
				return isDeleted;
			}
		}
	}
}
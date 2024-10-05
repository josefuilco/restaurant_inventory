using System.Data;
using Inventory.Api.Database;
using Inventory.Api.Module.Inventory.Domain.Builder;
using Inventory.Api.Module.Inventory.Domain.Model;
using Inventory.Api.Module.Inventory.Domain.Port.Repository;

namespace Inventory.Api.Module.Inventory.Adapter.Repository
{
    public class SqlServerProductRepository(SqlServerDatabase database) : IProductRepository
    {
        private readonly SqlServerDatabase database = database;

        public async Task<bool> AddAsync(Product entity, int userId)
        {
            var query = "EXEC sp_AgregarProducto @nombre, @precio, @stock, @stockMinimo, @proveedorId, @categoriaId, @userId";
            Console.WriteLine(entity);
            Console.WriteLine(userId);
            var rowAffected = await database.ExecuteNonQueryAsync(query, [
                new("@nombre", SqlDbType.VarChar, 30) {Value = entity.Name.Value},
                new("@precio", SqlDbType.Decimal) {Value = entity.Price.Value},
                new("@stock", SqlDbType.Int) {Value = entity.Quantity.Value},
                new("@stockMinimo", SqlDbType.Int) {Value = entity.MinimalQuantity.Value},
                new("@proveedorId", SqlDbType.TinyInt) {Value = entity.ProductProvider.Id},
                new("@categoriaId", SqlDbType.Int) {Value = entity.Category},
                new("@userId", SqlDbType.Int) {Value = userId}
            ]);
            return rowAffected > 0;
        }

        public async Task<bool> ChangeStockAsync(int productId, int quantity, int userId)
        {
            var query = "EXEC sp_ActualizarStock @iId_Prod, @CantidadActualizada, @IdUser";
            var rowAffected = await database.ExecuteNonQueryAsync(query, [
                new ("@iId_Prod", SqlDbType.Int) {Value = productId},
                new ("@CantidadActualizada", SqlDbType.Int) {Value = quantity},
                new ("@IdUser", SqlDbType.Int) {Value = userId}
            ]);
            return rowAffected > 0;
        }

        public async Task<IEnumerable<Product>> GetAllAsync()
        {
            var builder = new ProductBuilder();
            var query = "EXEC sp_TraerProductos";
            var table = await database.ExecuteTableQueryAsync(query, []);
            return from DataRow row
            in table.Rows
            select builder
            .AddId(Convert.ToInt32(row[0]))
            .AddName(Convert.ToString(row[1])!)
            .AddPrice(Convert.ToDecimal(row[2]))
            .AddQuantity(Convert.ToInt32(row[3]))
            .AddMinimalQuantity(Convert.ToInt32(row[4]))
            .AddProductProviderId(Convert.ToInt32(row[5]))
            .AddProductProviderName(Convert.ToString(row[6])!)
            .AddCategory(Convert.ToByte(row[7]))
            .Build();
        }

        public async Task<bool> RemoveAsync(int productId, int userId)
        {
            var query = "EXEC sp_BorrarProducto @iId_Prod, @IdUser";
            var rowAffected = await database.ExecuteNonQueryAsync(query, [
                new ("@iId_Prod", SqlDbType.Int) {Value = productId},
                new ("@IdUser", SqlDbType.Int) {Value = userId}
            ]);
            return rowAffected > 0;
        }

        public async Task<bool> UpdateAsync(Product entity, int userId)
        {
            var query = "EXEC sp_ActualizarProducto @iId_Prod, @vNom_Prod, @dPrecio_Prod, @iStock_Prod, @iStockMin_Prod, @iId_Prov, @tIdCatProd, @IdUser";
            var rowAffected = await database.ExecuteNonQueryAsync(query, [
                new ("@iId_Prod", SqlDbType.Int) {Value = entity.Id},
                new ("@vNom_Prod", SqlDbType.VarChar, 30) {Value = entity.Name.Value},
                new ("@dPrecio_Prod", SqlDbType.Decimal) {Value = entity.Price.Value},
                new ("@iStock_Prod", SqlDbType.Int) {Value = entity.Quantity.Value },
                new ("@iStockMin_Prod", SqlDbType.Int) {Value = entity.MinimalQuantity.Value},
                new ("@iId_Prov", SqlDbType.Int) {Value = entity.ProductProvider.Id},
                new ("@tIdCatProd", SqlDbType.TinyInt) {Value = entity.Category},
                new ("@IdUser", SqlDbType.Int) {Value = userId}
            ]);
            return rowAffected > 0;
        }
    }
}
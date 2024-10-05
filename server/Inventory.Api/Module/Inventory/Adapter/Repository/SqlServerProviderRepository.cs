using System.Data;
using Inventory.Api.Database;
using Inventory.Api.Module.Inventory.Domain.Model;
using Inventory.Api.Module.Inventory.Domain.Port.Repository;

namespace Inventory.Api.Module.Inventory.Adapter.Repository
{
    public class SqlServerProviderRepository(SqlServerDatabase sqlServer) : IProviderRepository
    {
        private readonly SqlServerDatabase sqlServer = sqlServer;

        #region Methods
        public async Task<bool> AddAsync(Provider entity)
        {
            var query = "EXEC sp_AgregarProveedor @Name, @Cellphone";
            var rowAffected = await sqlServer.ExecuteNonQueryAsync(query, [
                new("@Name", SqlDbType.VarChar, 30) {Value = entity.Name.Value},
                new("@Cellphone", SqlDbType.VarChar, 9) {Value = entity.Cellphone.Value}
            ]);
            return rowAffected > 0;
        }

        public async Task<IEnumerable<Provider>> GetAllAsync()
        {
            var query = "SELECT * FROM INVENTARIO.PROVEEDOR";
            var table = await sqlServer.ExecuteTableQueryAsync(query, []);
            return from DataRow row
            in table.Rows
            where Convert.ToBoolean(row[3])
            select new Provider(
                Convert.ToInt32(row[0]),
                new(Convert.ToString(row[1])!),
                new(Convert.ToString(row[2])!),
                true
            );
        }

        public async Task<bool> RemoveAsync(int id)
        {
            var query = "UPDATE INVENTARIO.PROVEEDOR SET bActivo=0 WHERE iId_Prov=@proveedorId";
            var rowAffected = await sqlServer.ExecuteNonQueryAsync(query, [
                new("@proveedorId", SqlDbType.Int) {Value = id},
            ]);
            return rowAffected > 0;
        }

        public async Task<bool> UpdateAsync(Provider entity)
        {
            var query = "UPDATE INVENTARIO.PROVEEDOR SET vTel_Prov=@celular WHERE iId_Prov=@proveedorId";
            var rowAffected = await sqlServer.ExecuteNonQueryAsync(query, [
                new("@proveedorId", SqlDbType.Int) {Value = entity.Id},
                new("@celular", SqlDbType.VarChar, 9) {Value = entity.Cellphone.Value}
            ]);
            return rowAffected > 0;
        }
        #endregion
    }
}
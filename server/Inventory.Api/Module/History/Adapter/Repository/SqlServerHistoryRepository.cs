using System.Data;
using Inventory.Api.Database;
using Inventory.Api.Module.History.Domain.Enums;
using Inventory.Api.Module.History.Domain.Model;
using Inventory.Api.Module.History.Domain.Port.Repository;
using Microsoft.Data.SqlClient;

namespace Inventory.Api.Module.History.Adapter.Repository
{
    public class SqlServerHistoryRepository : IHistoryRepository
    {
        private readonly SqlServerDatabase database;
        public SqlServerHistoryRepository(SqlServerDatabase database)
        {
            this.database = database;
        }
        public async Task<IEnumerable<ProductHistory>> FindHistoriesAsync(DateTime from, DateTime to)
        {
            List<ProductHistory> histories = [];
            var query = "EXEC sp_MostrarHistorial @From, @To";
            try
            {
                var table = await database.ExecuteTableQueryAsync(query, [
                    new("@From", SqlDbType.DateTime) { Value = from },
                    new("@To", SqlDbType.DateTime) { Value = to }
                ]);
                foreach (DataRow row in table.Rows)
                {
                    histories.Add(new(
                        Convert.ToInt32(row[0]),
                        Convert.ToInt32(row[1]),
                        Convert.ToInt32(row[2]),
                        Convert.ToDateTime(row[3]),
                        new(
                            Convert.ToInt32(row[4]),
                            Convert.ToString(row[5])!
                        ),
                        (Operation)Convert.ToByte(row[6]),
                        Convert.ToString(row[7])!.Replace("@", " "),
                        Convert.ToString(row[8])!
                    ));
                }
                return histories;
            }
            catch (SqlException ex)
            {
                Console.WriteLine("SQL Error: " + ex.Message);
                return histories;
            }
        }
    }
}
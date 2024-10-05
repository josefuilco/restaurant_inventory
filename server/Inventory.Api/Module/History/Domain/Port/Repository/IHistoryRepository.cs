using Inventory.Api.Module.History.Domain.Model;

namespace Inventory.Api.Module.History.Domain.Port.Repository
{
    public interface IHistoryRepository
    {
        Task<IEnumerable<ProductHistory>> FindHistoriesAsync(DateTime from, DateTime to);
    }
}
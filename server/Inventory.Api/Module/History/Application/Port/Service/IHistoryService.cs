using Inventory.Api.Module.History.Application.Dto;

namespace Inventory.Api.Module.History.Application.Port.Service
{
    public interface IHistoryService
    {
        Task<IEnumerable<ProductHistoryDto>> GetHistoriesAsync(int productId, DateTime from, DateTime to);
    }
}
using Inventory.Api.Module.History.Application.Dto;
using Inventory.Api.Module.History.Application.Port.Service;
using Inventory.Api.Module.History.Domain.Port.Repository;

namespace Inventory.Api.Module.History.Application.Service
{
    public class HistoryService : IHistoryService
    {
        private readonly IHistoryRepository repository;

        public HistoryService(IHistoryRepository repository)
        {
            this.repository = repository;
        }

        public async Task<IEnumerable<ProductHistoryDto>> GetHistoriesAsync(int productId, DateTime from, DateTime to)
        {
            var histories = await repository.FindHistoriesAsync(from, to);
            if (productId != 0)
            {
                return histories.Where(history => history.Product.Id == productId ).Select(history => new ProductHistoryDto(
                    history.Id,
                    history.CurrentQuantity,
                    history.LatestQuantity,
                    history.CalculateQuantityDiference(),
                    history.HistoryDate,
                    history.Product.Name,
                    history.UserName,
                    history.HistoryOperation.ToString(),
                    history.Detail
                ));
            }
            return histories.Select(history => new ProductHistoryDto(
                history.Id,
                history.CurrentQuantity,
                history.LatestQuantity,
                history.CalculateQuantityDiference(),
                history.HistoryDate,
                history.Product.Name,
                history.UserName,
                history.HistoryOperation.ToString(),
                history.Detail
            ));
        }
    }
}
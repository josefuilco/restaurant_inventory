using Inventory.Api.Module.Inventory.Domain.Model;
using Inventory.Api.Module.Shared.Domain.Port.Repository;

namespace Inventory.Api.Module.Inventory.Domain.Port.Repository
{
	public interface IProductRepository
	{
		Task<bool> AddAsync(Product entity, int userId);
        Task<IEnumerable<Product>> GetAllAsync();
        Task<bool> UpdateAsync(Product entity, int userId);
        Task<bool> RemoveAsync(int productId, int userId);
		Task<bool> ChangeStockAsync(int productId, int quantity, int userId);
	}
}
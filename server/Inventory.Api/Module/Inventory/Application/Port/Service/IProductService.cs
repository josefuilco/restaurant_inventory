using Inventory.Api.Module.Inventory.Application.Dto;
using Inventory.Api.Module.Inventory.Domain.Model;

namespace Inventory.Api.Module.Inventory.Application.Port.Service
{
    public interface IProductService
    {
        Task<bool> CreateProductAsync(Product product, int userId);
        Task<IEnumerable<ProductDto>> GetAllProductsAsync();
        Task<bool> UpdateProductAsync(Product product, int userId);
        Task<bool> UpdateStockProductAsync(int productId, int quantity, int userId);
        Task<bool> DeleteProductAsync(int productId, int userId);
    }
}
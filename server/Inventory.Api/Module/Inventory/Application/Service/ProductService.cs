using Inventory.Api.Module.Inventory.Application.Dto;
using Inventory.Api.Module.Inventory.Application.Port.Service;
using Inventory.Api.Module.Inventory.Domain.Model;
using Inventory.Api.Module.Inventory.Domain.Port.Repository;
using Inventory.Api.Module.Inventory.Domain.ValueObject;

namespace Inventory.Api.Module.Inventory.Application.Service
{
    public class ProductService : IProductService
    {
        private readonly IProductRepository repository;

        public ProductService(IProductRepository repository)
        {
            this.repository = repository;
        }

        public async Task<bool> CreateProductAsync(Product product, int userId)
        {
            var isCreated = await repository.AddAsync(product, userId);
            return isCreated;
        }

        public async Task<bool> DeleteProductAsync(int productId, int userId)
        {
            var isDeleted = await repository.RemoveAsync(productId, userId);
            return isDeleted;
        }

        public async Task<IEnumerable<ProductDto>> GetAllProductsAsync()
        {
            var products = await repository.GetAllAsync();
            return from p in products select new ProductDto(
                p.Id,
                p.Name.Value,
                p.Price.Value,
                p.Quantity.Value,
                p.MinimalQuantity.Value,
                p.ProductProvider.Name.Value,
                p.Category.ToString(),
                p.Measure.ToString()
            ); 
        }

        public async Task<bool> UpdateProductAsync(Product product, int userId)
        {
            var isUpdated = await repository.UpdateAsync(product, userId);
            return isUpdated;
        }

        public async Task<bool> UpdateStockProductAsync(int productId, int quantity, int userId)
        {
            var quantityVo = new ProductQuantity(quantity);
            var isUpdated = await repository.ChangeStockAsync(productId, quantityVo.Value, userId);
            return isUpdated;
        }
    }
}
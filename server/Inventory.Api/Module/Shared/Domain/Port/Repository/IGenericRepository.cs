namespace Inventory.Api.Module.Shared.Domain.Port.Repository
{
    public interface IGenericRepository<Entity>
    {
        Task<bool> AddAsync(Entity entity);
        Task<IEnumerable<Entity>> GetAllAsync();
        Task<bool> UpdateAsync(Entity entity);
        Task<bool> RemoveAsync(int id);
    }
}
using Inventory.Api.Module.Inventory.Domain.Model;
using Inventory.Api.Module.Shared.Domain.Port.Repository;

namespace Inventory.Api.Module.Inventory.Domain.Port.Repository
{
	public interface IProviderRepository : IGenericRepository<Provider>;
}
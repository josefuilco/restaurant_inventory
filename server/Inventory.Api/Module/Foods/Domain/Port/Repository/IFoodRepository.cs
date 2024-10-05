using Inventory.Api.Module.Foods.Domain.Model;
using Inventory.Api.Module.Shared.Domain.Port.Repository;

namespace Inventory.Api.Module.Foods.Domain.Port.Repository
{
	public interface IFoodRepository : IGenericRepository<Food>;
}
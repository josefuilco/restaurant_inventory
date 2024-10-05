using Inventory.Api.Module.Foods.Application.Dto;
using Inventory.Api.Module.Foods.Domain.Model;

namespace Inventory.Api.Module.Foods.Application.Port.Service
{
	public interface IFoodService
	{
		Task<bool> CreateFoodAsync(Food food);
		Task<IEnumerable<FoodDto>> GetAllFoodAsync();
		Task<bool> UpdateFoodAsync(Food food);
		Task<bool> DeleteFoodAsync(int id);
	}
}
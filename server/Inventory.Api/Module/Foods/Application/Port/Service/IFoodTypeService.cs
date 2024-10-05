using Inventory.Api.Module.Foods.Application.Dto;

namespace Inventory.Api.Module.Foods.Application.Port.Service
{
	public interface IFoodTypeService
	{
		IEnumerable<FoodTypeDto> GetFoodTypes();
	}
}
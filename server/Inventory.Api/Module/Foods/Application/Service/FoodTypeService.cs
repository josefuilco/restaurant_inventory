using Inventory.Api.Module.Foods.Application.Dto;
using Inventory.Api.Module.Foods.Application.Port.Service;
using Inventory.Api.Module.Foods.Domain.Enums;
using Inventory.Api.Module.Shared.Application.Util;

namespace Inventory.Api.Module.Foods.Application.Service
{
	public class FoodTypeService : IFoodTypeService
	{
		public IEnumerable<FoodTypeDto> GetFoodTypes()
		{
			var foodTypes = ReflexionEnum.ListValues<FoodType>();
			return from f in foodTypes select new FoodTypeDto(f.Value, f.Key);
		}
	}
}
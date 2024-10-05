using Inventory.Api.Module.Foods.Application.Dto;
using Inventory.Api.Module.Foods.Application.Port.Service;
using Inventory.Api.Module.Foods.Domain.Model;
using Inventory.Api.Module.Foods.Domain.Port.Repository;

namespace Inventory.Api.Module.Foods.Application.Service
{
	public class FoodService : IFoodService
	{
		private readonly IFoodRepository repository;

		public FoodService(IFoodRepository repository)
		{
			this.repository = repository;
		}

		public async Task<bool> CreateFoodAsync(Food food)
		{
			var isCreated = await repository.AddAsync(food);
			if (!isCreated) throw new Exception("Food No Created");
			return isCreated;
		}
		public async Task<IEnumerable<FoodDto>> GetAllFoodAsync()
		{
			var foods = await repository.GetAllAsync();
			foreach (var foodDto in foods)
			{
				Console.WriteLine(foodDto.Id);
			}
			return from food in foods select new FoodDto(
				food.Id,
				food.Name.Value,
				food.Price.Value,
				food.Amount.Value,
				food.Type.ToString()
			);
		}
		public async Task<bool> UpdateFoodAsync(Food food)
		{
			var isUpdated = await repository.UpdateAsync(food);
			if (!isUpdated) throw new Exception("Food No Updated");
			return isUpdated;
		}
		public async Task<bool> DeleteFoodAsync(int id)
		{
			var isRemoved = await repository.RemoveAsync(id);
			if (!isRemoved) throw new Exception("Food No Removed");
			return isRemoved;
		}
	}
}
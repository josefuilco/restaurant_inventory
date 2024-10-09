import type { IFoodRepository } from "../../domain/repository/IFoodRepository";
import type { IFoodStoreService } from "../../domain/service/IFoodStoreService";

export const GetFoods = async (storeService: IFoodStoreService, repository: IFoodRepository) => {
	const foods = await repository.GetFoods();
	storeService.saveFoods(foods);
}
import type { FoodCreationModel } from "../../domain/model/FoodCreationModel";
import type { IFoodRepository } from "../../domain/repository/IFoodRepository";
import type { IFoodStoreService } from "../../domain/service/IFoodStoreService";
import { GetFoods } from "./GetFoods";

export const UpdateFood = async (foodId: number, food: FoodCreationModel, storeService: IFoodStoreService, repository: IFoodRepository) => {
	await repository.UpdateFood(foodId, food);
	await GetFoods(storeService, repository);
}
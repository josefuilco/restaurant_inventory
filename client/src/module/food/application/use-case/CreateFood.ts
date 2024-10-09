import type { FoodCreationModel } from "../../domain/model/FoodCreationModel";
import type { IFoodRepository } from "../../domain/repository/IFoodRepository";
import type { IFoodStoreService } from "../../domain/service/IFoodStoreService";
import { GetFoods } from "./GetFoods";

export const CreateFood = async (food: FoodCreationModel, storeService: IFoodStoreService, repository: IFoodRepository) => {
	await repository.AddFood(food);
	await GetFoods(storeService, repository);
}
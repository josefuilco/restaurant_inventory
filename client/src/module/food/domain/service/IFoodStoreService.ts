import type { FoodInformation } from "../model/FoodInformation";

export interface IFoodStoreService {
	saveFoods(foods: FoodInformation[]): void;
}
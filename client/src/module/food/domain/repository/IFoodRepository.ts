import type { FoodCreationModel } from "../model/FoodCreationModel";
import type { FoodInformation } from "../model/FoodInformation";

export interface IFoodRepository {
	GetFoods(): Promise<FoodInformation[]>;
	AddFood(food: FoodCreationModel): Promise<void>;
	UpdateFood(foodId: number, food: FoodCreationModel): Promise<void>;
	RemoveFood(foodId: number): Promise<void>;
}
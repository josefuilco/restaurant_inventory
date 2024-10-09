import type { IFoodStoreService } from "../../domain/service/IFoodStoreService";
import { useFoodStore } from "../store/FoodStore";

const foodStore = useFoodStore();
export const PiniaFoodStoreService: IFoodStoreService = {
	saveFoods(foods) {
		foodStore.setFood(foods);
	},
}
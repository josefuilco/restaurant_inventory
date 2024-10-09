import { DataProvider } from "@/data/DataProvider";
import type { IFoodRepository } from "../../domain/repository/IFoodRepository";
import { ensureFoodInformation, type FoodInformation } from "../../domain/model/FoodInformation";

const dataProvider = DataProvider.getInstance();
export const ApiFoodRepository: IFoodRepository = {
	async AddFood(food) {
		const { message } = await dataProvider.post('Food/create', {
			"name": food.name,
			"price": food.price,
			"amount": food.amount,
			"type": food.type
		})
		console.info(message);
	},
	async GetFoods() {
		const foods: FoodInformation[] = [];
		const { data } = await dataProvider.get('Food/list');
		data.forEach((food: any) => {
			foods.push(ensureFoodInformation(
				food.id,
				food.name,
				food.price,
				food.amount,
				food.type
			))
		})
		return foods;
	},
	async UpdateFood(foodId, food) {
		const { message } = await dataProvider.put(`Food/update/${foodId}`, {
			"name": food.name,
			"price": food.price,
			"amount": food.amount,
			"type": food.type
		});
		console.info(message);
	},
	async RemoveFood(foodId) {
		const { message } = await dataProvider.put(`Food/remove/${foodId}`);
		console.info(message);
	},
}
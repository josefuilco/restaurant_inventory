import { defineStore } from "pinia";
import type { FoodInformation } from "../../domain/model/FoodInformation";

interface State {
	foods: FoodInformation[] | undefined,
	filter: number
}

export const useFoodStore = defineStore('food', {
	state: (): State => ({
		foods: undefined,
		filter: 0
	}),
	getters: {
		getFoods(state) {
			return state.foods;
		},
		getFilter(state) {
			return state.filter;
		}
	},
	actions: {
		setFood(foods: FoodInformation[]) {
			this.foods = foods;
		},
		setFilter(filter: number) {
			this.filter = filter;
		}
	}
})
import { defineStore } from "pinia";
import type { Product } from "../../domain/entity/Product";

interface State {
	products: Product[] | undefined,
	filter: number
}

export const useProductStore = defineStore('product', {
	state: (): State => ({
		products: undefined,
		filter: 0
	}),
	getters: {
		getProducts(state) {
			return state.products;
		},
		getFilter(state) {
			return state.filter;
		}
	},
	actions: {
		setProducts(products: Product[]) {
			this.products = products;
		},
		setFilter(filter: number) {
			this.filter = filter;
		}
	}
})
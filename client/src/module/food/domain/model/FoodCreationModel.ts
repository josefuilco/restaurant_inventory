export interface FoodCreationModel {
	name: string,
	price: number,
	amount: number,
	type: number
}

export function ensureFoodCreationModel(
	name: string,
	price: number,
	amount: number,
	type: number
): FoodCreationModel {
	return {
		name,
		price,
		amount,
		type
	}
}
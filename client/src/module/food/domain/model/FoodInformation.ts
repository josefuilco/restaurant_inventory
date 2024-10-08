export interface FoodInformation {
	id: number,
	name: string,
	price: number,
	amount: number,
	type: string
}

export function ensureFoodInformation(
	id: number,
	name: string,
	price: number,
	amount: number,
	type: string
): FoodInformation {
	return {
		id,
		name,
		price,
		amount,
		type
	}
}
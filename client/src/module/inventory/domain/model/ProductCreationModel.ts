export interface ProductCreationModel {
	name: string;
	price: number;
	quantity: number;
	minimal_quantity: number;
	provider_id: number;
	category_id: number;
	user_id: number;
}

export function ensureProductCreationModel(
	name: string,
	price: number,
	quantity: number,
	minimal_quantity: number,
	provider_id: number,
	category_id: number,
	user_id: number
): ProductCreationModel {
	return {
		name,
		price,
		quantity,
		minimal_quantity,
		provider_id,
		category_id,
		user_id
	}
}
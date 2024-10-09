export interface Product {
	id: number;
	name: string;
	price: number;
	quantity: number;
	minimal_quantity: number;
	provider_name: string;
	category_name: string;
	measure_name: string;
}

export function ensureProduct(
	id: number,
	name: string,
	price: number,
	quantity: number,
	minimal_quantity: number,
	provider_name: string,
	category_name: string,
	measure_name: string
): Product {
	return {
		id,
		name,
		price,
		quantity,
		minimal_quantity,
		provider_name,
		category_name,
		measure_name
	}
}
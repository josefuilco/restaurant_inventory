export interface Provider {
	id: number;
	name: string;
	cellphone: string;
}

export function ensureProvider(
	id: number,
	name: string,
	cellphone: string
): Provider {
	return {
		id,
		name,
		cellphone
	}
}
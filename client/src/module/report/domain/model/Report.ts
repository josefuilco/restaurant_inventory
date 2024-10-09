export interface Report {
	id: number;
	current_amount: number;
	latest_amount: number;
	total_amount_diference: number;
	history_date: string;
	product_name: string;
	user_name: string;
	operation_name: string;
	description: string;
}

export function ensureReport(
	id: number,
	current_amount: number,
	latest_amount: number,
	total_amount_diference: number,
	history_date: string,
	product_name: string,
	user_name: string,
	operation_name: string,
	description: string
): Report {
	return {
		id,
		current_amount,
		latest_amount,
		total_amount_diference,
		history_date,
		product_name,
		user_name,
		operation_name,
		description
	}
}
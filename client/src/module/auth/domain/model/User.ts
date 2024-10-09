export interface User {
	username: string;
	password: string;
	email: string
	role: number;
}

export const ensureUser = (
	username: string,
	password: string,
	email: string,
	role: number
): User => {
	return {
		username,
		password,
		email,
		role
	}
}
export interface UserInfo {
	id: number;
	name: string;
	email: string;
	creationDate: string;
	role: 1 | 2;
}

export const ensureUserInfo = (
	id: number,
	name: string,
	email: string,
	creationDate: string,
	role: 1 | 2
): UserInfo => {
	return {
		id,
		name,
		email,
		creationDate,
		role
	}
}
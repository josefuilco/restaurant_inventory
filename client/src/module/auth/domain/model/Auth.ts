export interface Auth {
	username: string;
	password: string;
}

export function ensureAuth(username: string, password: string): Auth {
	const isValid = username != '' && password != '';
	if (!isValid) throw new Error('Auth.Invalid');
	return {
		username,
		password
	}
}
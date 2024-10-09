import type { IStorageService } from "../../domain/service/IStorageService";

export const LocalStorageService: IStorageService = {
	save(token) {
		globalThis.localStorage.setItem('token', token);
	},
	obtain(item) {
		const value = globalThis.localStorage.getItem(item);
		return value;
	},
}
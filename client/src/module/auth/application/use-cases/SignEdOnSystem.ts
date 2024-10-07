import type { IStorageService } from "../../domain/service/IStorageService";

export const SignEdOnSystem = (storageService: IStorageService) => {
	return storageService.obtain('token');
}
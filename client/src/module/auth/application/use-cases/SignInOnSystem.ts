import type { Auth } from "../../domain/model/Auth";
import type { IAuthRepository } from "../../domain/repository/IAuthRepository";
import type { IStorageService } from "../../domain/service/IStorageService";

export const SignInOnSystem = async (authModel: Auth, authRepository: IAuthRepository, storageService: IStorageService) => {
	const token = await authRepository.signInAsync(authModel.username, authModel.password);
	if (!token) throw new Error('Acceso no permitido');
	storageService.save(token);
}
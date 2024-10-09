import type { IUserInfoRepository } from "../../domain/repository/IUserInfoRepository";
import type { IUserStoreService } from "../../domain/service/IUserStoreService";

export const saveUserInfoInStore = async (token: string, service: IUserStoreService, repository: IUserInfoRepository) => {
	const userInfo = await repository.findByToken(token);
	service.saveUserInfo(userInfo);
}
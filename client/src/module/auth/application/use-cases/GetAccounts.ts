import type { IUserStoreService } from "@/module/common/domain/service/IUserStoreService";
import type { IUserRepository } from "../../domain/repository/IUserRepository";

export const GetAccounts = async (service: IUserStoreService, repository: IUserRepository) => {
	const accounts = await repository.getAccounts();
	service.saveAccounts(accounts);
}
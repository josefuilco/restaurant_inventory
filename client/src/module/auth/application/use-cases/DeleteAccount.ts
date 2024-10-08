import type { IUserStoreService } from "@/module/common/domain/service/IUserStoreService";
import type { IUserRepository } from "../../domain/repository/IUserRepository";
import { GetAccounts } from "./GetAccounts";

export const DeleteAccount = async (id: number, service: IUserStoreService, repository: IUserRepository) => {
	await repository.removeAccount(id);
	await GetAccounts(service, repository);
}
import type { IUserStoreService } from "@/module/common/domain/service/IUserStoreService";
import type { IUserRepository } from "../../domain/repository/IUserRepository";
import { type User } from "../../domain/model/User";
import { GetAccounts } from "./GetAccounts";

export const CreateAccount = async (user: User, service: IUserStoreService, repository: IUserRepository) => {
	await repository.addAccount(user);
	await GetAccounts(service, repository);
}
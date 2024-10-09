import type { IUserRepository } from "../../domain/repository/IUserRepository";

export const ChangePasswordAccount = async (id: number, oldPassword: string, newPassowrd: string, repository: IUserRepository) => {
	const changed = await repository.changePasswordAccount(id, oldPassword, newPassowrd);
	return changed;
}
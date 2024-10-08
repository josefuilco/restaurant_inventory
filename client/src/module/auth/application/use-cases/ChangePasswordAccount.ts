import type { IUserRepository } from "../../domain/repository/IUserRepository";

export const ChangePasswordAccount = async (id: number, oldPassword: string, newPassowrd: string, repository: IUserRepository) => {
	await repository.changePasswordAccount(id, oldPassword, newPassowrd);
}
import { DataProvider } from "@/data/DataProvider";
import type { IUserRepository } from "../../domain/repository/IUserRepository";
import { ensureUserInfo, type UserInfo } from "@/module/common/domain/model/UserInfo";
import { simpleDateFormat } from "@/lib/date-format/simpleDateFormat";

const dataProvider = DataProvider.getInstance();

export const ApiUserRepository: IUserRepository = {
	async addAccount(user) {
		const { message } = await dataProvider.post('User/create', {
			username: user.username,
			password: user.password,
			email: user.email,
			role: user.role
		});
		console.info(message);
	},
	async getAccounts() {
		const accounts: UserInfo[] = [];
		const { data } = await dataProvider.get('User/list');
		data.forEach((user: any) => {
			accounts.push(ensureUserInfo(
				user["id"],
				user["name"],
				user["email"],
				simpleDateFormat(user["creation_date"]),
				user["role"]
			));
		});
		return accounts;
	},
	async removeAccount(id) {
		console.log(id)
		const { message } = await dataProvider.put(`User/remove/${id}`);
		console.info(message);
	},
	async changePasswordAccount(id, oldPassword, newPassword) {
		const { message } = await dataProvider.put(`User/change-password/${id}`, {
			"current_password": oldPassword,
			"new_password": newPassword
		});
		console.info(message);
	},
}